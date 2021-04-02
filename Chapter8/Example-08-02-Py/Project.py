import numpy as np
import cv2

src = cv2.imread("egg.jpg")
data = src.reshape(-1, 3).astype(np.float32)

K = 3
criteria = (cv2.TERM_CRITERIA_MAX_ITER + cv2.TERM_CRITERIA_EPS, 10, 0.001)
retval, bestLabels, centers = cv2.kmeans(data, K, None, criteria, 10, cv2.KMEANS_RANDOM_CENTERS)

centers = centers.astype(np.uint8)
dst = centers[bestLabels].reshape(src.shape)

cv2.imshow("dst", dst)
cv2.waitKey()
cv2.destroyAllWindows()