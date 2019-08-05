import cv2

src = cv2.imread("OpenCV_Logo.png", cv2.IMREAD_GRAYSCALE)

cv2.namedWindow("src", flags=cv2.WINDOW_FREERATIO)
cv2.resizeWindow("src", 400, 200)
cv2.imshow("src", src)
cv2.waitKey(0)
cv2.destroyWindow("src")