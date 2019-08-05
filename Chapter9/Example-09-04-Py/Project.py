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
