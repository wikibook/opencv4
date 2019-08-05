using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("image.jpg");
            Mat gray = new Mat();
            Mat hist = new Mat();
            Mat result = Mat.Ones(new Size(256, src.Height), MatType.CV_8UC1);
            Mat dst = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.CalcHist(new Mat[] { gray }, new int[] { 0 }, null, hist, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);

            for (int i = 0; i < hist.Rows; i++)
            {
                Cv2.Line(result, new Point(i, src.Height), new Point(i, src.Height - hist.Get<float>(i)), Scalar.White);
            }

            Cv2.HConcat(new Mat[] { gray, result }, dst);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
