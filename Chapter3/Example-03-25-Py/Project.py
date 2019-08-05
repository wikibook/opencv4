import numpy as np

array = np.array([[[1, 2],
                 [3, 4]],
                [[5, 6],
                 [7, 8]]])

for i in array[0]:
    for j in i:
        if j % 2 == 0:
            print(j)