import cv2

src = cv2.imread("swan.jpg")
_, binary = cv2.threshold(src, 127, 255, cv2.THRESH_BINARY)

cv2.imshow("binary", binary)
cv2.waitKey(0)
cv2.destroyAllWindows()