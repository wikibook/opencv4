using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("ferris-wheel.jpg");
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.PyrUp(src, dst, new Size(src.Width*2+1, src.Height*2-1));

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}