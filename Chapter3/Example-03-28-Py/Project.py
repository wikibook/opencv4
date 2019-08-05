import numpy as np 

array = np.arange(4)

axis1 = array[np.newaxis]
axis2 = array[:, np.newaxis]

print(axis1)
print(axis2)