using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("dummy.jpg");
            Mat gray = new Mat();
            Mat dst = src.Clone();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            Point2f[] corners = Cv2.GoodFeaturesToTrack(gray, 100, 0.03, 5, null, 3, false, 0);
            Point2f[] sub_corners = Cv2.CornerSubPix(gray, corners, new Size(3, 3), new Size(-1, -1), TermCriteria.Both(10, 0.03));

            for (int i = 0; i < corners.Length; i++)
            {
                Point pt = new Point((int)corners[i].X, (int)corners[i].Y);
                Cv2.Circle(dst, pt, 5, Scalar.Yellow, Cv2.FILLED);
            }

            for (int i = 0; i < sub_corners.Length; i++)
            {
                Point pt = new Point((int)sub_corners[i].X, (int)sub_corners[i].Y);
                Cv2.Circle(dst, pt, 5, Scalar.Red, Cv2.FILLED);
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}