using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat m = Mat.Eye(new Size(3, 3), MatType.CV_64FC3);

            Console.WriteLine(m.At<double>(0, 0));
            Console.WriteLine(m.At<Vec3d>(0, 0).Item0);
            Console.WriteLine(m.At<Vec3d>(1, 1).Item1);
            Console.WriteLine(m.At<Vec3d>(2, 2).Item2);
            Console.WriteLine(m.At<Point3d>(2, 2));
            Console.WriteLine(m.At<long>(2, 2));
        }
    }
}