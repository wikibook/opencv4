using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMat sm = new SparseMat(new int[] { 1, 1 }, MatType.CV_32F);

            SparseMat.Indexer<Vec3f> indexer = sm.GetIndexer<Vec3f>();
            //SparseMat.Indexer<Vec3f> indexer = sm.Ref<Vec3f>();

            indexer[0, 0] = new Vec3f(4, 5, 6);
            //sm.GetIndexer<Vec3f>()[0, 0] = new Vec3f(4, 5, 6);

            Console.WriteLine(sm.Get<Vec3f>(0, 0).Item0);
            Console.WriteLine(sm.Get<Vec3f>(0, 0).Item1);
            Console.WriteLine(sm.Get<Vec3f>(0, 0).Item2);
        }
    }
}