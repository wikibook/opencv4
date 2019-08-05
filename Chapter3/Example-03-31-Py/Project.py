import numpy as np 

array = np.arange(10).reshape(2, 5)

detach1 = np.split(array, 2, axis=0)
detach2 = np.split(array, [2, 3], axis=1)

print(detach1)
print(detach2)