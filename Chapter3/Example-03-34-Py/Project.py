import numpy as np

array = np.zeros((1280, 1920, 3), np.uint8)

x, y, w, h = 100, 100, 300, 300
roi = array[x:x+w, y:y+h]

print(array.shape)
print(roi.shape)