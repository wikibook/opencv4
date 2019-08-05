using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("car.png");
            Mat dst = new Mat(new Size(1, 1), MatType.CV_8UC3);

            dst = src.SubMat(280, 310, 240, 405);
            Cv2.Resize(dst, dst, new Size(9999, 0), 2.0, 2.0, InterpolationFlags.Cubic);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}