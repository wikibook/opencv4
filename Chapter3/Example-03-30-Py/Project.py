import numpy as np 

array1 = np.arange(6).reshape(2, 3)
array2 = np.arange(6, 12).reshape(2, 3)

merge1 = np.stack([array1, array2], axis=0)
merge2 = np.stack([array1, array2], axis=-1)

print(merge1)
print(merge2)