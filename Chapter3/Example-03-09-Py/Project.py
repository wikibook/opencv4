import numpy as np
import cv2

# 실행을 위한 추가 코드
src = cv2.imread("OpenCV_Logo.png", 0)

dsize = [cv2.THRESH_BINARY, cv2.THRESH_BINARY_INV, cv2.THRESH_OTSU]
img = [None] * len(dsize)

for i in range(len(dsize)):
    ret, img[i] = cv2.threshold(src, 100, 255, dsize[i])

cv2.imshow("img_0", img[0])

# 실행을 위한 추가 코드
cv2.waitKey(0)