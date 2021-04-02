import cv2

img = cv2.imread("image.jpg")
img_object = cv2.imread("object.jpg", cv2.IMREAD_GRAYSCALE)
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

orb = cv2.ORB_create(nfeatures=40000)
kp1, des1 = orb.detectAndCompute(gray, None)
kp2, des2 = orb.detectAndCompute(img_object, None)

bf = cv2.BFMatcher(cv2.NORM_HAMMING, crossCheck=True)
matches = bf.match(des1, des2)
matches = sorted(matches, key=lambda x: x.distance)

count = 100
for i in matches[:count]:
    idx = i.queryIdx
    x1, y1 = kp1[idx].pt
    cv2.circle(img, (int(x1), int(y1)), 3, (0, 0, 255), 3)

flag = (cv2.DRAW_MATCHES_FLAGS_NOT_DRAW_SINGLE_POINTS | cv2.DRAW_MATCHES_FLAGS_DRAW_RICH_KEYPOINTS)
matching_result = cv2.drawMatches(img, kp1, img_object, kp2, matches[:count], None, flags=flag)

cv2.imshow("Matching result", matching_result)
cv2.waitKey(0)