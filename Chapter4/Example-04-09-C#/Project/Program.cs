using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoCapture capture = new VideoCapture(0);
            Mat frame = new Mat();
            capture.Set(CaptureProperty.FrameWidth, 640);
            capture.Set(CaptureProperty.FrameHeight, 480);

            while(true)
            {
                if (capture.IsOpened() == true)
                {
                    capture.Read(frame);
                    Cv2.ImShow("VideoFrame", frame);
                    if (Cv2.WaitKey(33) == 'q') break;
                }
            }

            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}