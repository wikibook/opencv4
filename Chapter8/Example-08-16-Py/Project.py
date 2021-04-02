import cv2

prototxt = "./caffe_model/bvlc_googlenet.prototxt";
caffeModel = "./caffe_model/bvlc_googlenet.caffemodel";
with open("./caffe_model/bvlc_googlenet.txt") as file:
    classNames = file.read().splitlines()

image = cv2.imread("umbrella.jpg");
net = cv2.dnn.readNetFromCaffe(prototxt, caffeModel)
inputBlob = cv2.dnn.blobFromImage(image, 1, (224, 224), (104, 117, 123))

net.setInput(inputBlob)
outputBlobs = net.forward("prob")

_, classProb, _, classNumber = cv2.minMaxLoc(outputBlobs)
print("Class Number :", classNumber[0])
print("Class Name :", classNames[classNumber[0]])
print("Probability :", classProb)