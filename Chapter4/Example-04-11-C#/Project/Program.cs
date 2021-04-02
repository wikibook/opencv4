using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat one = new Mat("one.jpg");
            Mat two = new Mat("two.jpg");
            Mat three = new Mat("three.jpg");
            Mat four = new Mat("four.jpg");

            Mat left = new Mat();
            Mat right = new Mat();
            Mat dst = new Mat();

            Cv2.VConcat(new Mat[] { one, three }, left);
            Cv2.VConcat(new Mat[] { two, four }, right);
            Cv2.HConcat(new Mat[] { left, right }, dst);

            Cv2.ImShow("dst", dst); 
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}