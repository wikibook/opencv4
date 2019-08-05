import numpy as np
import tensorflow as tf

with tf.gfile.GFile("frozen_inference_graph.pb", "rb") as f:
    graph = tf.GraphDef()
    graph.ParseFromString(f.read())
 
with tf.Session() as sess:
    tf.import_graph_def(graph, name="") 
