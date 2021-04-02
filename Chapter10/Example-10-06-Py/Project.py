with open("mscoco_complete_label_map.pbtxt", "rt") as f:
    pb_classes = f.read().rstrip("\n").split("\n")

    print(pb_classes[0])
    print(pb_classes[1])
    print(pb_classes[2])
    print(pb_classes[3])
    print(pb_classes[4])
