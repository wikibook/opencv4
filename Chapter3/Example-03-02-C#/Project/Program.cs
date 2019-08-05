using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Vec3d Vector = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt1 = new Vec3d(1.0, 2.0, 3.0);
            Point3d Pt2 = Vector;

            Console.WriteLine(Pt1);
            Console.WriteLine(Pt2);
            Console.WriteLine(Pt1.X);
        }
    }
}
