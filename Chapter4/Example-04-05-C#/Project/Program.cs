using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoCapture capture = new VideoCapture("Star.mp4");
            Mat frame = new Mat();

            while(true)
            {
                if (capture.PosFrames == capture.FrameCount) capture.Open("star.mp4");

                capture.Read(frame);
                Cv2.ImShow("VideoFrame", frame);
                    
                if (Cv2.WaitKey(33) == 'q') break;
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}