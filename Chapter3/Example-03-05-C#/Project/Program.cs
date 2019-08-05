using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Size size = new Size(640, 480);
            Mat img = new Mat(size, MatType.CV_8UC3);
            Mat img2 = new Mat(img.Size(), MatType.CV_8UC3);

            Console.WriteLine($"{size.Width}, {size.Height}");
            Console.WriteLine(img.Size());
            Console.WriteLine($"{img.Size().Width}, {img.Size().Height}");
            Console.WriteLine($"{img.Width}, {img.Height}");
        }
    }
}