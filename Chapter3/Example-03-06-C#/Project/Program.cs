using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range = new Range(0, 100);
            Console.WriteLine($"{range.Start}, {range.End}");
        }
    }
}