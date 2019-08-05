import numpy as np
import tensorflow as tf
import cv2

with tf.gfile.GFile("frozen_inference_graph.pb", "rb") as f:
    graph = tf.GraphDef()
    graph.ParseFromString(f.read())
 
with tf.Session() as sess:
    tf.import_graph_def(graph, name="")
 
    capture = cv2.VideoCapture("bird.mp4")
    while True:
        ret, frame = capture.read()
 
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