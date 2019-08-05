import numpy as np
import cv2

src = cv2.imread("dandelion.jpg", cv2.IMREAD_GRAYSCALE)
_, binary = cv2.threshold(src, 127, 255, cv2.THRESH_BINARY)

kernel = np.array([[1, 0, 0, 0, 1],
                 [0, 1, 0, 1, 0],
                 [0, 0, 1, 0, 0],
                 [0, 1, 0, 1, 0],
                 [1, 0, 0, 0, 1]])

dst = cv2.morphologyEx(binary, cv2.MORPH_HITMISS, kernel, iterations=1)

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()