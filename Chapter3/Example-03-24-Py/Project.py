import numpy as np

array1 = np.array([1, 2, 3])
array2 = np.array([[1, 2],
                   [3, 4]])
array3 = np.array([[[1, 2],
                    [3, 4]],
                    [[5, 6],
                    [7, 8]]])

print(array1[-1])
print(array2[0][1])
print(array3[0][1][1])