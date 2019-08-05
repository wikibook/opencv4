import numpy as np
import cv2

img = np.zeros((768, 1366, 3), dtype = np.uint8)

cv2.line(img, (100, 100), (1200, 100), (0, 0, 255), 3, cv2.LINE_AA)
cv2.circle(img, (300, 300), 50, (0, 255, 0), cv2.FILLED, cv2.LINE_4)
cv2.rectangle(img, (500, 200), (1000, 400), (255, 0, 0), 5, cv2.LINE_8)
cv2.ellipse(img, (1200, 300), (100, 50), 0, 90, 180, (255, 255, 0), 2)

pts1 = np.array([[[100, 500], [300, 500], [200, 600]], [[400, 500], [500, 500], [600, 700]]])
pts2 = np.array([[700, 500], [800, 500], [700, 600]])
cv2.polylines(img, pts1, True, (0, 255, 255), 2)
cv2.fillPoly(img, [pts2], (255, 0, 255), cv2.LINE_AA)

cv2.putText(img, "OpenCV", (900, 600), cv2.FONT_HERSHEY_COMPLEX | cv2.FONT_ITALIC, 2, (255, 255, 255), 3)

cv2.imshow("img", img)
cv2.waitKey(0)
cv2.destroyAllWindows()