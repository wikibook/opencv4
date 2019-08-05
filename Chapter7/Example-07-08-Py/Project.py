import cv2

src = cv2.imread("dummy.jpg")
dst = src.copy()

gray = cv2.cvtColor(src, cv2.COLOR_RGB2GRAY)
corners = cv2.goodFeaturesToTrack(gray, 100, 0.01, 5, blockSize=3, useHarrisDetector=True, k=0.03)

for i in corners:
    cv2.circle(dst, tuple(i[0]), 3, (255, 0, 0), 5)

criteria = (cv2.TERM_CRITERIA_MAX_ITER + cv2.TERM_CRITERIA_EPS, 30, 0.001)
cv2.cornerSubPix(gray, corners, (5, 5), (-1, -1), criteria)

for i in corners:
    cv2.circle(dst, tuple(i[0]), 3, (0, 0, 255), 5)

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()