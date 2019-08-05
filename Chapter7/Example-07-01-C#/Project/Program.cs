using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("book.jpg", ImreadModes.Grayscale);
            Mat dst = new Mat();

            Cv2.Sobel(src, dst, MatType.CV_8UC1, 1, 0, 3, 1, 0, BorderTypes.Reflect101);
        
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}