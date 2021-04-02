using System;
using OpenCvSharp;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 0;
            Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3);
            TrackbarCallbackNative trackbarCallback = new TrackbarCallbackNative(Event);

            Cv2.NamedWindow("Palette");
            Cv2.CreateTrackbar("Color", "Palette", ref value, 255, trackbarCallback, src.CvPtr);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        private static void Event(int pos, IntPtr userdata)
        {
            Mat color = new Mat(userdata);
            color.SetTo(new Scalar(pos, pos, pos));
            Cv2.ImShow("Palette", color);
        }
    }
}