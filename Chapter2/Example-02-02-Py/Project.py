import numpy as np

width, height = 640, 480
rows, cols = 480, 640

color = np.zeros((height, width, 3), np.uint8)
gray = np.zeros((rows, cols, 1), np.uint8)