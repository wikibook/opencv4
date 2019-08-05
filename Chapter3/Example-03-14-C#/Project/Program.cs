using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> sizes = new List<int>() { 480, 640 };
            Mat m = new Mat(sizes, MatType.CV_8UC3);
        }
    }
}