import cv2

src = cv2.imread("crescent.jpg")

dst = cv2.bilateralFilter(src, 100, 33, 11, borderType=cv2.BORDER_ISOLATED)

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()