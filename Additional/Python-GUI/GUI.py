import cv2
import numpy as np
import tkinter as tk
from PIL import Image
from PIL import ImageTk

class GUI:
    
    # PIL 라이브러리를 필요로 합니다.
    # PIL : pip install image

    def __init__(self, window):
        # tkinter 설정
        self.window = window
        self.window.title("Form")
        self.window.geometry("640x400+100+100")
        self.window.resizable(True, True)

        # Blue 이미지 생성
        image = np.zeros((480, 640, 3), np.uint8)
        image[:,:,0] = 255

        # BGR to RGB
        image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)

        # tkinter와 호환되는 객체로 변환
        imgtk = Image.fromarray(image)
        imgtk = ImageTk.PhotoImage(image=imgtk)

        # 가비지 컬렉터(garbage collector)가 이미지를 삭제하지 않도록 등록
        label = tk.Label(window, image=imgtk)
        label.image = imgtk
        label.pack(side="top")

if __name__ == '__main__':
    window = tk.Tk()
    GUI(window)
    window.mainloop()