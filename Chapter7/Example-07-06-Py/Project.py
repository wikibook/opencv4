import cv2

src = cv2.imread("chess.png")
dst = src.copy()

kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))

gray = cv2.cvtColor(src, cv2.COLOR_RGB2GRAY)
ret, binary = cv2.threshold(gray, 230, 255, cv2.THRESH_BINARY)
morp = cv2.morphologyEx(binary, cv2.MORPH_CLOSE, kernel, iterations=2)
image = cv2.bitwise_not(morp)

contours, hierarchy = cv2.findContours(image, cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)

for i in contours:
    perimeter = cv2.arcLength(i, True)
    epsilon = perimeter * 0.05
    approx = cv2.approxPolyDP(i, epsilon, True)
    cv2.drawContours(dst, [approx], 0, (0, 0, 255), 3)
    for j in approx:
        cv2.circle(dst, tuple(j[0]), 3, (255, 0, 0), -1)
    
cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()