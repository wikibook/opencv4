import numpy as np
import cv2

# 실행을 위한 추가 코드
img = cv2.imread("OpenCV_Logo.png")

center = [100, 100]
red = (0, 0, 255)

cv2.circle(img, tuple(center), 30, red, 3)

# 실행을 위한 추가 코드
cv2.imshow("img", img)
cv2.waitKey(0)