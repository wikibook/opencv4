import cv2

capture = cv2.VideoCapture("Star.mp4")

while True:
    ret, frame = capture.read()

    if(capture.get(cv2.CAP_PROP_POS_FRAMES) == capture.get(cv2.CAP_PROP_FRAME_COUNT)):
        capture.open("Star.mp4")

    cv2.imshow("VideoFrame", frame)
    if cv2.waitKey(33) == ord('q'): break

capture.release()
cv2.destroyAllWindows()