import numpy as np

array = np.arange(12).reshape(3,-1)

flat1 = array.flatten(order='F')
flat2 = array.ravel()

print(flat1)
print(flat2)