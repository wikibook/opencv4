import numpy as np 

array1 = np.array([1, 2, 3, 4]).reshape(2, 2)
array2 = np.array([5, 6, 7, 8]).reshape(2, 2)

mat1 = np.mat(array1)
mat2 = np.mat(array2)

print(mat1.T * mat2)
print(mat1 ** 2)