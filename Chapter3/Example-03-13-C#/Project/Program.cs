using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat M = new Mat();
            M.Create(MatType.CV_8UC3, new int[] { 480, 640 });
            // M.Create(new Size(640, 480), MatType.CV_8UC3);
            // M.Create(480, 640, MatType.CV_8UC3);
            M.SetTo(new Scalar(255, 0, 0));
        }
    }
}