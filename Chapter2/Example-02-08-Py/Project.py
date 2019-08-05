import cv2
import numpy as np

image = cv2.imread("image.jpg")
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
result = np.zeros((image.shape[0], 256), dtype=np.uint8)

hist = cv2.calcHist([image], [0], None, [256], [0, 256])
cv2.normalize(hist, hist, 0, 255, cv2.NORM_MINMAX)

for x, y in enumerate(hist):
    cv2.line(result, (x, image.shape[0]), (x, image.shape[0]-y), 255)

dst = np.hstack([image[:,:,0], result])
cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()