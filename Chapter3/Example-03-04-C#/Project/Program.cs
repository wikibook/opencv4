using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Scalar s1 = new Scalar(255, 127);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
        }
    }
}
