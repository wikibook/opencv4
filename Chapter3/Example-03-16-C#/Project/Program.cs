using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat m = Mat.Eye(new Size(2, 2), MatType.CV_8UC2);

            for (int y = 0; y < m.Rows; y++)
            {
                for (int x = 0; x < m.Cols; x++)
                {
                    int offset = (int)m.Step() * y + m.ElemSize() * x;  // 오프셋 지정
                    byte i = Marshal.ReadByte(m.Ptr(0), offset + 0);    // 첫 번째 채널
                    //byte j = Marshal.ReadByte(m.Ptr(0), offset + 1);	// 두 번째 채널
                    //byte k = Marshal.ReadByte(m.Ptr(0), offset + 2); 	// 세 번째 채널
                    Console.WriteLine($"{offset} - ({y}, {x}) : {i}");
                }
            }
        }
    }
}