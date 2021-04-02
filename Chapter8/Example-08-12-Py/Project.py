import numpy as np
import cv2

label_dict = {
    0 : "T-shirt/top",
    1 : "Trouser",
    2 : "Pullover",
    3 : "Dress",
    4 : "Coat",
    5 : "Sandal",
    6 : "Shirt",
    7 : "Sneaker",
    8 : "Bag",
    9 : "Ankle boot"
}


def loadTrainData(image_path, label_path):
    with open(image_path, 'rb') as image_data:
        images = np.frombuffer(image_data.read(), dtype=np.uint8, offset=16).reshape(-1, 784)

    with open(label_path, 'rb') as label_data:
        labels = np.frombuffer(label_data.read(), dtype=np.uint8, offset=8)

    return images, labels


train_x, train_y = loadTrainData("./fashion-mnist/train-images-idx3-ubyte", "./fashion-mnist/train-labels-idx1-ubyte")
test_x, test_y = loadTrainData("./fashion-mnist/t10k-images-idx3-ubyte", "./fashion-mnist/t10k-labels-idx1-ubyte")

svm = cv2.ml_SVM.create()
svm.setType(cv2.ml.SVM_C_SVC)
svm.setKernel(cv2.ml.SVM_POLY)
svm.setDegree(3)
svm.setGamma(5.0)
svm.setC(3.0)
svm.setCoef0(0)
svm.train(train_x.astype(np.float32), cv2.ml.ROW_SAMPLE, train_y.astype(np.int32))

count = 500
retval, results = svm.predict(test_x[:count].astype(np.float32))
matches = results.astype(np.uint8) == test_y[:count][:, None]
print(np.count_nonzero(matches) / count * 100)