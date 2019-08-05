import cv2

src = cv2.imread("chess.png")
dst = src.copy()

kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))

gray = cv2.cvtColor(src, cv2.COLOR_RGB2GRAY)
ret, binary = cv2.threshold(gray, 230, 255, cv2.THRESH_BINARY)
morp = cv2.morphologyEx(binary, cv2.MORPH_CLOSE, kernel, iterations=2)
image = cv2.bitwise_not(morp)

contours, hierarchy = cv2.findContours(image, cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)
cv2.drawContours(dst, contours, -1, (0, 0, 255), 3)
for i in range(len(contours)):
    cv2.putText(dst, str(i), tuple(contours[i][0][0]), cv2.FONT_HERSHEY_COMPLEX, 1.3, (255, 0, 0), 1)
    print(i, hierarchy[0][i])

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()