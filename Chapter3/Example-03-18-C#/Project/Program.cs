using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMat sm = new SparseMat(new int[] { 1, 1 }, MatType.CV_8UC3);

            sm.Ref<Vec3b>()[99, 1000] = new Vec3b(100, 0, 0);
            Console.WriteLine(sm.Find<Vec3b>(99, 1000).Value.Item0);
        }
    }
}