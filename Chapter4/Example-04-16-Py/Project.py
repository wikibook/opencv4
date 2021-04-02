import cv2
import numpy as np

def onChangeBlue(pos):
    global b
    b = pos
    cv2.imshow("Palette", createImage(b, g, r))

def createImage(b, g, r):
    return np.full((500, 500, 3), (b, g, r), dtype=np.uint8)

b, g, r = 0, 0, 0
cv2.namedWindow("Palette")
cv2.createTrackbar("Blue", "Palette", 55, 255, onChangeBlue)
cv2.createTrackbar("Green", "Palette", 0, 255, lambda x:x)
cv2.createTrackbar("Red", "Palette", 0, 255, lambda x:x)

while True:
    g = cv2.getTrackbarPos("Green", "Palette")
    r = cv2.getTrackbarPos("Red", "Palette")
    
    cv2.imshow("Palette", createImage(b, g, r))
    if cv2.waitKey(33) & 0xFF == ord('q'):
        break

cv2.destroyAllWindows()