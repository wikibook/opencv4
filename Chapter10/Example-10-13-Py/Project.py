import re
import cv2
import numpy as np
import tensorflow as tf


with open("mscoco_complete_label_map.pbtxt", "rt") as f:
    pb_classes = f.read().rstrip("\n").split("\n")
    classes_label = dict()

    for i in range(0, len(pb_classes), 5):
        pb_classId = int(re.findall("\d+", pb_classes[i + 2])[0])
        pattern = 'display_name: "(.*?)"'
        pb_text = re.search(pattern, pb_classes[i + 3])
        classes_label[pb_classId] = pb_text.group(1)

model = tf.saved_model.load("./ssd_mobilenet_v2_320x320_coco17_tpu-8/saved_model")
capture = cv2.VideoCapture("bird.mp4")
ret, prev_frame = capture.read()
prev_gray = cv2.cvtColor(prev_frame, cv2.COLOR_BGR2GRAY)
prev_pts = cv2.goodFeaturesToTrack(prev_gray, mask=None, maxCorners=1000, qualityLevel=0.1, minDistance=5, blockSize=9)

while True:
    ret, next_frame = capture.read()
    next_gray = cv2.cvtColor(next_frame, cv2.COLOR_BGR2GRAY)
    frame = next_frame.copy()

    if capture.get(cv2.CAP_PROP_POS_FRAMES) == capture.get(cv2.CAP_PROP_FRAME_COUNT):
        break

    input_img = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    input_tensor = tf.convert_to_tensor(input_img)
    input_tensor = input_tensor[tf.newaxis, ...]

    output_dict = model.signatures["serving_default"](input_tensor)

    classes = output_dict["detection_classes"][0]
    scores = output_dict["detection_scores"][0]
    boxes = output_dict["detection_boxes"][0]

    height, width, _ = frame.shape
    for idx, score in enumerate(scores):
        if score > 0.7:
            class_id = int(classes[idx])
            box = boxes[idx]

            x1 = int(box[1] * width)
            y1 = int(box[0] * height)
            x2 = int(box[3] * width)
            y2 = int(box[2] * height)

            cv2.rectangle(frame, (x1, y1), (x2, y2), 255, 1)
            cv2.putText(frame, classes_label[class_id] + ":" + str(float(score)), (x1, y1 - 5), cv2.FONT_HERSHEY_COMPLEX, 1.5, (0, 255, 255), 1)

    prev_gray = next_gray.copy()
    cv2.imshow("Object Detection", frame)
    if cv2.waitKey(33) == ord("q"):
        break
