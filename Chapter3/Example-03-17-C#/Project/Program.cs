using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat m = Mat.Eye(new Size(2, 2), MatType.CV_32FC3);

            for (int y = 0; y < m.Rows; y++)
            {
                for (int x = 0; x < m.Cols; x++)
                {
                    int offset = (int)m.Step() * y + m.ElemSize() * x;  // offset 지정
                    Vec3f i = Marshal.PtrToStructure<Vec3f>(m.Ptr(0) + offset + 0);
                    Console.WriteLine($"{offset} - ({y}, {x}) : {i.Item0}, {i.Item1}, {i.Item2}");
                }
            }
        }
    }
}