using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("tomato.jpg");
            Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);
            Mat[] HSV = Cv2.Split(hsv);
            Mat H_orange = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.InRange(HSV[0], new Scalar(8), new Scalar(20), H_orange);

            Cv2.BitwiseAnd(hsv, hsv, dst, H_orange);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);

            Cv2.ImShow("Orange", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}