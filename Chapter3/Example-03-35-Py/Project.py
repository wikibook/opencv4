import numpy as np

array = np.zeros((1280, 1920, 3), np.uint8)

coi = array[:, :, 0]

print(array.shape)
print(coi.shape)