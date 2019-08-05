using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Point Pt1 = new Point(1, 2);
            Point Pt2 = new Point(3, 2);

            Console.WriteLine(Pt1.DistanceTo(Pt2));
            Console.WriteLine(Pt1.DotProduct(Pt2));
            Console.WriteLine(Pt1.CrossProduct(Pt2));
            Console.WriteLine(Pt1 + Pt2);
            Console.WriteLine(Pt1 - Pt2);
            Console.WriteLine(Pt1 == Pt2);
            Console.WriteLine(Pt1 * 0.5);
        }
    }
}
