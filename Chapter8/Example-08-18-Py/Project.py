import cv2
import numpy as np

cfgFile = "darknet_model/yolov3.cfg"
darknetModel = "darknet_model/yolov3.weights"
with open("darknet_model/yolov3.txt") as file:
    classNames = file.read().splitlines()

labels = list()
scores = list()
bboxes = list()

image = cv2.imread("umbrella.jpg")
net = cv2.dnn.readNetFromDarknet(cfgFile, darknetModel)
inputBlob = cv2.dnn.blobFromImage(image, 1 / 255.0, (416, 416), crop=False)

net.setInput(inputBlob)
outBlobNames = net.getUnconnectedOutLayersNames()
outputBlobs = net.forward(outBlobNames)

for prob in outputBlobs:
    for p in prob:
        confidence = p[4]

        if confidence > 0.9:
            _, _, _, classNumber = cv2.minMaxLoc(p[5:])
            classes = classNumber[1]
            probability = p[classes + 5]

            if probability > 0.9:
                centerX = p[0] * image.shape[1]
                centerY = p[1] * image.shape[0]
                width = p[2] * image.shape[1]
                height = p[3] * image.shape[0]

                labels.append(classNames[classes])
                scores.append(float(probability))
                bboxes.append([int(centerX - width / 2), int(centerY - height / 2), int(width), int(height)])

indices = cv2.dnn.NMSBoxes(bboxes, scores, 0.9, 0.5)
for i in indices:
    x, y, w, h = bboxes[int(i)]
    cv2.rectangle(image, (x, y), (x + w, y + h), (0, 0, 255))
    cv2.putText(image, labels[int(i)], (x, y), cv2.FONT_HERSHEY_COMPLEX, 1.0, (0, 0, 255))

cv2.imshow("image", image)
cv2.waitKey()
cv2.destroyAllWindows()