using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Vec4d vector1 = new Vec4d(1.0, 2.0, 3.0, 4.0);
            Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);

            Console.WriteLine(vector1.Item0);
            Console.WriteLine(vector1[1]);
            Console.WriteLine(vector1.Equals(vector2));
        }
    }
}
