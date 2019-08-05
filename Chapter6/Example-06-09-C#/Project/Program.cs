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

            Mat kernel= Cv2.GetStructuringElement(MorphShapes.Cross, new Size(7, 7));
            Cv2.Dilate(src, dst, kernel, new Point(-1, -1), 3, BorderTypes.Reflect101, new Scalar(0));

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}