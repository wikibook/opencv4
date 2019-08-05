using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 640;
            int height = 480;

            int rows = 480;
            int cols = 640;

            Mat color = new Mat(new Size(width, height), MatType.CV_8UC3);
            Mat gray = new Mat(rows, cols, MatType.CV_8UC1);
        }
    }
}
