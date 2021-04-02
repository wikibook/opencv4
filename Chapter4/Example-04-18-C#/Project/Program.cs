using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(new Size(640, 480), MatType.CV_8UC3);
            bool save;

            ImageEncodingParam[] prms = new ImageEncodingParam[] {
                new ImageEncodingParam(ImwriteFlags.JpegQuality, 100),
                new ImageEncodingParam(ImwriteFlags.JpegProgressive, 1)
            };

            save = Cv2.ImWrite("CV.jpeg", img, prms);
            Console.WriteLine(save);
        }
    }
}