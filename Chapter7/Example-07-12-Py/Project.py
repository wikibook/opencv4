import cv2

src = cv2.imread("colorball.png")
dst = src.copy()

image = cv2.cvtColor(src, cv2.COLOR_BGR2GRAY)

circles = cv2.HoughCircles(image, cv2.HOUGH_GRADIENT, 1, 100, param1=100, param2=35, minRadius=80, maxRadius=120)

for i in circles[0]:
    cv2.circle(dst, (i[0], i[1]), i[2], (255, 255, 255), 5)

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()