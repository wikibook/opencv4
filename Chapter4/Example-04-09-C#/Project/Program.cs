using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(new Size(1366, 768), MatType.CV_8UC3);

            Cv2.Line(img, new Point(100, 100), new Point(1200, 100), new Scalar(0, 0, 255), 3, LineTypes.AntiAlias);
            Cv2.Circle(img, new Point(300, 300), 50, new Scalar(0, 255, 0), Cv2.FILLED, LineTypes.Link4);
            Cv2.Rectangle(img, new Point(500, 200), new Point(1000, 400), new Scalar(255, 0, 0), 5);
            Cv2.Ellipse(img, new Point(1200, 300), new Size(100, 50), 0, 90, 180, new Scalar(255, 255, 0), 2);

            List<List<Point>> pts1 = new List<List<Point>>();
            List<Point> pt1 = new List<Point>()
            {
               new Point(100, 500),
               new Point(300, 500),
               new Point(200, 600)
            };
            List<Point> pt2 = new List<Point>()
            {
                new Point(400, 500),
                new Point(500, 500),
                new Point(600, 700),
                new Point(500, 650)

            };
            pts1.Add(pt1);
            pts1.Add(pt2);
            Cv2.Polylines(img, pts1, true, new Scalar(0, 255, 255), 2);

            Point[] pt3 = new Point[] {
                new Point(700, 500),
                new Point(800, 500),
                new Point(700, 600)
            };

            Point[][] pts2 = new Point[][] { pt3 };
            Cv2.FillPoly(img, pts2, new Scalar(255, 0, 255), LineTypes.AntiAlias);

            Cv2.PutText(img, "OpenCV", new Point(900, 600), HersheyFonts.HersheyComplex | HersheyFonts.Italic, 2.0, new Scalar(255, 255, 255), 3);

            Cv2.ImShow("img", img);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}