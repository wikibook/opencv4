import cv2

src = cv2.imread("OpenCV_Logo.png", cv2.IMREAD_GRAYSCALE)

print(src.ndim, src.shape, src.dtype)