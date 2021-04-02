using System;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Dnn;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            const string config = "tensorflow_model/graph.pbtxt";
            const string model = "tensorflow_model/frozen_inference_graph.pb";
            string[] classNames = File.ReadAllLines("tensorflow_model/labelmap.txt");

            Mat image = new Mat("umbrella.jpg");
            Net net = Net.ReadNetFromTensorflow(model, config);
            Mat inputBlob = CvDnn.BlobFromImage(image, 1, new Size(300, 300), swapRB: true, crop: false);

            net.SetInput(inputBlob);
            Mat outputBlobs = net.Forward();

            Mat prob = new Mat(outputBlobs.Size(2), outputBlobs.Size(3), MatType.CV_32F, outputBlobs.Ptr(0));
            for (int p = 0; p < prob.Rows; p++)
            {
                float confidence = prob.At<float>(p, 2);
                if (confidence > 0.9)
                {
                    int classes = (int)prob.At<float>(p, 1);
                    string label = classNames[classes];

                    int x1 = (int)(prob.At<float>(p, 3) * image.Width);
                    int y1 = (int)(prob.At<float>(p, 4) * image.Height);
                    int x2 = (int)(prob.At<float>(p, 5) * image.Width);
                    int y2 = (int)(prob.At<float>(p, 6) * image.Height);

                    Cv2.Rectangle(image, new Point(x1, y1), new Point(x2, y2), new Scalar(0, 0, 255));
                    Cv2.PutText(image, label, new Point(x1, y1), HersheyFonts.HersheyComplex, 1.0, Scalar.Red);
                }
            }
            Cv2.ImShow("image", image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}