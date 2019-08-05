pt1 = [(50, 0), (170, 180), (210, 250)]
pt2 = [(50, 0), (170, 170), (210, 250)]

union = set(pt1) | set(pt2)	
intersection = set(pt1) & set(pt2)
difference = set(pt1) - set(pt2)

print(union)
print(intersection)
print(difference)