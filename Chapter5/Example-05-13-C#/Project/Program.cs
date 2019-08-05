using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("crescent.jpg");
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.GaussianBlur(src, dst, new Size(9, 9), 3, 3, BorderTypes.Isolated);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}