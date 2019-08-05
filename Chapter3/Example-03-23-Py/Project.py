import numpy as np

array1 = np.array([[1, 2, 3], [4, 5, 6]])
array2 = np.array([1, 2, 3], dtype=complex, ndmin=3)
array3 = np.array(array1, copy=False)
array4 = np.array(np.mat('1 2; 3 4'), subok=True)

array1[0] = [4, 5, 6]

print(array1) 
print(array2) 
print(array3) 
print(type(array4))