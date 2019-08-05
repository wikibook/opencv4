using System;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tesseract;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("card.png");

            OpenCvSharp.Point[] squares = Square(src);
            Mat square = DrawSquare(src, squares);
            
            Cv2.ImShow("square", square);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        static double Angle(OpenCvSharp.Point pt1, OpenCvSharp.Point pt0, OpenCvSharp.Point pt2)
        {
            double u1 = pt1.X - pt0.X;
            double u2 = pt1.Y - pt0.Y;
            double v1 = pt2.X - pt0.X;
            double v2 = pt2.Y - pt0.Y;

            return (u1 * v1 + u2 * v2) / (Math.Sqrt(u1 * u1 + u2 * u2) * Math.Sqrt(v1 * v1 + v2 * v2));
        }
        
        public static OpenCvSharp.Point[] Square(Mat src)
        {
            Mat[] split = Cv2.Split(src);
            Mat blur = new Mat();
            Mat binary = new Mat();
            OpenCvSharp.Point[] squares = new OpenCvSharp.Point[4];
            
            int N = 10;
            double max = src.Size().Width * src.Size().Height * 0.9;
            double min = src.Size().Width * src.Size().Height * 0.1;

            for (int channel = 0; channel < 3; channel++)
            {
                Cv2.GaussianBlur(split[channel], blur, new OpenCvSharp.Size(5, 5), 1);
                for (int i = 0; i < N; i++)
                {
                    Cv2.Threshold(blur, binary, i * 255 / N, 255, ThresholdTypes.Binary);
                    
                    OpenCvSharp.Point[][] contours;
                    HierarchyIndex[] hierarchy;
                    Cv2.FindContours(binary, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxTC89KCOS);

                    for (int j = 0; j < contours.Length; j++)
                    {
                        double perimeter = Cv2.ArcLength(contours[j], true);
                        OpenCvSharp.Point[] result = Cv2.ApproxPolyDP(contours[j], perimeter * 0.02, true);

                        double area = Cv2.ContourArea(result);
                        bool convex = Cv2.IsContourConvex(result);

                        if (result.Length == 4 && area > min && area < max && convex)
                        {
                            double cos = 0;
                            for (int k = 1; k < 5; k++)
                            {
                                double t = Math.Abs(Angle(result[(k - 1) % 4], result[k % 4], result[(k + 1) % 4]));
                                cos = cos > t ? cos : t;
                            }
                            if (cos < 0.15) squares = result;
                        }
                    }
                }
            }
            return squares;
        }

        public static Mat DrawSquare(Mat src, OpenCvSharp.Point[] squares)
        {
            Mat drawsquare = src.Clone();
            OpenCvSharp.Point[][] pts = new OpenCvSharp.Point[][] { squares };
            Cv2.Polylines(drawsquare, pts, true, Scalar.Yellow, 3, LineTypes.AntiAlias, 0);
            return drawsquare;
        }

        public static Mat PerspectiveTransform(Mat src, OpenCvSharp.Point[] squares)
        {
            //...
        }
    }
}