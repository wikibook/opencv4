import numpy as np
import tensorflow as tf
import cv2
import re
 
with open("mscoco_complete_label_map.pbtxt", "rt") as f:
    pb_classes = f.read().rstrip('\n').split('\n')
 
    classes_label = dict()
    for i in range(0, len(pb_classes), 5):
        pb_classId = int(re.findall("\d+", pb_classes[i+2])[0])
        pattern = "display_name: \"(.*?)\""
        pb_text = re.search(pattern, pb_classes[i+3])
        classes_label[pb_classId] = pb_text.group(1)
 
with tf.gfile.GFile("frozen_inference_graph.pb", "rb") as f:
    graph = tf.GraphDef()
    graph.ParseFromString(f.read())
 
with tf.Session() as sess:
    tf.import_graph_def(graph, name="")
 
    capture = cv2.VideoCapture("bird.mp4")
    ret, prev_frame = capture.read()
    prev_gray = cv2.cvtColor(prev_frame, cv2.COLOR_BGR2GRAY)

    while True:
        ret, next_frame = capture.read()
        next_gray = cv2.cvtColor(next_frame, cv2.COLOR_BGR2GRAY)
        frame = next_frame.copy()

        if(capture.get(cv2.CAP_PROP_POS_FRAMES) == capture.get(cv2.CAP_PROP_FRAME_COUNT)):
            break
 
        input_img = cv2.resize(frame, (300, 300))
        input_img = cv2.cvtColor(input_img, cv2.COLOR_BGR2RGB)
        
        num_detections, scores, classes, boxes = sess.run(
            fetches=[sess.graph.get_tensor_by_name("num_detections:0"),
                    sess.graph.get_tensor_by_name("detection_scores:0"),
                    sess.graph.get_tensor_by_name("detection_classes:0"),
                    sess.graph.get_tensor_by_name("detection_boxes:0")],
            feed_dict={"image_tensor:0": input_img.reshape(1, input_img.shape[0], input_img.shape[1], input_img.shape[2])}
            )
 
        rows, cols, _ = frame.shape
        for i in range(int(num_detections[0])):
            class_id = int(classes[0][i])
            score = scores[0][i]
            box = boxes[0][i]
            
            if score > 0.7:
                x1 = int(box[1] * cols)
                y1 = int(box[0] * rows)
                x2 = int(box[3] * cols)
                y2 = int(box[2] * rows)
 
                cv2.putText(frame, classes_label[class_id] + ":" + str(score), (x1, y1-5), cv2.FONT_HERSHEY_COMPLEX, 1.0, (0, 0, 255), 1)
                cv2.rectangle(frame, (x1, y1), (x2, y2), (255, 0, 0), 5)
 
        prev_gray = next_gray.copy()
        cv2.imshow("Object Detection", frame)
        if cv2.waitKey(33) == ord('q'): break