using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("crow.jpg");
            Mat dst = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}