from object_detection.utils.label_map_util import get_label_map_dict


label_map = get_label_map_dict("mscoco_complete_label_map.pbtxt", True)
label = dict()
for item in label_map.items():
    label[item[1]] = item[0]
