import numpy as np
import cv2

def loadTrainData(image_path, label_path):
    with open(image_path, 'rb') as image_data:
        images = np.frombuffer(image_data.read(), dtype=np.uint8, offset=16).reshape(-1, 784)

    with open(label_path, 'rb') as label_data:
        labels = np.frombuffer(label_data.read(), dtype=np.uint8, offset=8)

    return images, labels


train_x, train_y = loadTrainData("./fashion-mnist/train-images-idx3-ubyte", "./fashion-mnist/train-labels-idx1-ubyte")
test_x, test_y = loadTrainData("./fashion-mnist/t10k-images-idx3-ubyte", "./fashion-mnist/t10k-labels-idx1-ubyte")

cv2.imshow("images", train_x[0].reshape(28, 28, 1))
cv2.waitKey()
cv2.destroyAllWindows()