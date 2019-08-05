using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Rect rect1 = new Rect(new Point(0, 0), new Size(640, 480));
            Rect rect2 = new Rect(100, 100, 640, 480);

            Console.WriteLine(rect1);
            Console.WriteLine(rect2);
        }
    }
}