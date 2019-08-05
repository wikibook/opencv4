import cv2

src = cv2.imread("swan.jpg")
gray = cv2.cvtColor(src, cv2.COLOR_BGR2GRAY)
binary = cv2.adaptiveThreshold(gray, 255, cv2.ADAPTIVE_THRESH_MEAN_C, cv2.THRESH_BINARY, 33, -5)

cv2.imshow("binary", binary)
cv2.waitKey(0)
cv2.destroyAllWindows()