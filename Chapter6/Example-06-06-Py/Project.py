import math
import cv2

src = cv2.imread("glass.jpg")

height, width, _ = src.shape
center = (width / 2, height / 2)
angle = 90
scale = 0.5
matrix = cv2.getRotationMatrix2D(center, angle, scale)

radians = math.radians(angle)
sin = math.sin(radians)
cos = math.cos(radians)
bound_w = int((height * scale * abs(sin)) + (width * scale * abs(cos))) 
bound_h = int((height * scale * abs(cos)) + (width * scale * abs(sin)))

matrix[0, 2] += ((bound_w / 2) - center[0])
matrix[1, 2] += ((bound_h / 2) - center[1])

dst = cv2.warpAffine(src, matrix, (bound_w, bound_h))

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()