import numpy as np
import cv2

img = np.zeros((480, 640, 3), dtype = np.uint8)

save = cv2.imwrite("CV.jpeg", img, (cv2.IMWRITE_JPEG_QUALITY, 100, cv2.IMWRITE_JPEG_PROGRESSIVE, 1))
print(save)