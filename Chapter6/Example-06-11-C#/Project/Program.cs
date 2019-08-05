using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("dandelion.jpg", ImreadModes.Grayscale);
            Mat dst = new Mat();

            Mat kernel = Mat.Zeros(new Size(7, 7), MatType.CV_8UC1);
            kernel[0, 7, 0, 1] = Mat.Ones(new Size(1, 7), MatType.CV_8UC1);
            kernel[0, 1, 0, 7] = Mat.Ones(new Size(7, 1), MatType.CV_8UC1);

            Cv2.MorphologyEx(src, dst, MorphTypes.HitMiss, kernel, iterations: 10);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}