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


train_x, train_y = loadTrainData("train-images-idx3-ubyte", "train-labels-idx1-ubyte")
test_x, test_y= loadTrainData("t10k-images-idx3-ubyte", "t10k-labels-idx1-ubyte")

hog = cv2.HOGDescriptor((28, 28), (8, 8), (4, 4), (4, 4), 9, 1, -1., 0, 0.2, 1, 28, True)
train_descriptor = np.float32(list(map(hog.compute, train_x.reshape(-1, 28, 28, 1))))
test_descriptor = np.float32(list(map(hog.compute, test_x.reshape(-1, 28, 28, 1))))

svm = cv2.ml_SVM.create()
svm.setType(cv2.ml.SVM_C_SVC)
svm.setKernel(cv2.ml.SVM_RBF)
svm.setGamma(0.5)
svm.setC(0.5)
svm.train(train_descriptor, cv2.ml.ROW_SAMPLE, train_y.astype(np.int32))

count = 500
retval, results = svm.predict(test_descriptor[:count])
matches = results.astype(np.uint8) == test_y[:count][:, None]
print(np.count_nonzero(matches) / count * 100)