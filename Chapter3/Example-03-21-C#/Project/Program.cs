using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat m = new Mat(1280, 1920, MatType.CV_8UC3);

            Mat coi = m.ExtractChannel(0);
            Console.WriteLine(coi);
        }
    }
}