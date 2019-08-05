using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat m = new Mat(1280, 1920, MatType.CV_8UC3);

            Mat roi1 = new Mat(m, new Rect(300, 300, 100, 100));
            Mat roi2 = m[0, 100, 0, 100];
            Mat roi3 = m.SubMat(100, 300, 200, 300);

            Console.WriteLine(m);
            Console.WriteLine(roi1);
            Console.WriteLine(roi2);
            Console.WriteLine(roi3);
        }
    }
}