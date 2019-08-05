import numpy as np
import cv2

src = cv2.imread("card.jpg")
dst = src.copy()

kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3), (-1, -1))

gray = cv2.cvtColor(src, cv2.COLOR_BGR2GRAY)
_, binary = cv2.threshold(gray, 150, 255, cv2.THRESH_BINARY)
morp = cv2.dilate(binary, kernel)
morp = cv2.erode(morp, kernel, iterations=3)
morp = cv2.dilate(morp, kernel, iterations=2)
canny = cv2.Canny(morp, 0, 0, apertureSize=3, L2gradient=True)

lines = cv2.HoughLines(canny, 1, np.pi/180, 140, srn=50, stn=10, min_theta=0, max_theta=np.pi/2)

for i in lines:
    rho, theta = i[0][0], i[0][1]
    a, b = np.cos(theta), np.sin(theta)
    x0, y0 = a*rho, b*rho

    scale = src.shape[0] + src.shape[1]

    x1 = int(x0 + scale * -b)
    y1 = int(y0 + scale * a)
    x2 = int(x0 - scale * -b)
    y2 = int(y0 - scale * a)

    cv2.line(dst, (x1, y1), (x2, y2), (0, 255, 255), 2)
    cv2.circle(dst, (x0, y0), 3, (255, 0, 0), 5, cv2.FILLED)

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()