using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("clouds.jpg");
            Mat dst = new Mat();

            List<Point2f> src_pts = new List<Point2f>()
            {
               new Point2f(0.0f, 0.0f),
               new Point2f(0.0f, src.Height),
               new Point2f(src.Width, src.Height)
            };

            List<Point2f> dst_pts = new List<Point2f>()
            {
               new Point2f(300.0f, 300.0f),
               new Point2f(300.0f, src.Height),
               new Point2f(src.Width-400.0f, src.Height-200.0f)
            };

            Mat M = Cv2.GetAffineTransform(src_pts, dst_pts);

            Cv2.WarpAffine(
                src, dst, M, new Size(src.Width, src.Height),
                borderValue: new Scalar(127, 127, 127, 0)
            );

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}