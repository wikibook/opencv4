using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.Dnn;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            const string cfgFile = "darknet_model/yolov3.cfg";
            const string darknetModel = "darknet_model/yolov3.weights";
            string[] classNames = File.ReadAllLines("darknet_model/yolov3.txt");

            List<string> labels = new List<string>();
            List<float> scores = new List<float>();
            List<Rect> bboxes = new List<Rect>();

            Mat image = new Mat("umbrella.jpg");
            Net net = Net.ReadNetFromDarknet(cfgFile, darknetModel);
            Mat inputBlob = CvDnn.BlobFromImage(image, 1/255f, new Size(416, 416), crop:false);

            net.SetInput(inputBlob);
            var outBlobNames = net.GetUnconnectedOutLayersNames();
            var outputBlobs = outBlobNames.Select(toMat => new Mat()).ToArray();

            net.Forward(outputBlobs, outBlobNames);
            foreach (Mat prob in outputBlobs)
            {
                for (int p = 0; p < prob.Rows; p++)
                {
                    float confidence = prob.At<float>(p, 4);
                    if (confidence > 0.9)
                    {
                        Cv2.MinMaxLoc(prob.Row(p).ColRange(5, prob.Cols), out _, out _, out _, out Point classNumber);

                        int classes = classNumber.X;
                        float probability = prob.At<float>(p, classes + 5);

                        if (probability > 0.9)
                        {
                            float centerX = prob.At<float>(p, 0) * image.Width;
                            float centerY = prob.At<float>(p, 1) * image.Height;
                            float width = prob.At<float>(p, 2) * image.Width;
                            float height = prob.At<float>(p, 3) * image.Height;

                            labels.Add(classNames[classes]);
                            scores.Add(probability);
                            bboxes.Add(new Rect((int)centerX - (int)width / 2, (int)centerY - (int)height / 2, (int)width, (int)height));
                        }
                    }
                }
            }

            CvDnn.NMSBoxes(bboxes, scores, 0.9f, 0.5f, out int[] indices);

            foreach (int i in indices)
            {
                Cv2.Rectangle(image, bboxes[i], Scalar.Red, 1);
                Cv2.PutText(image, labels[i], bboxes[i].Location, HersheyFonts.HersheyComplex, 1.0, Scalar.Red);
            }

            Cv2.ImShow("image", image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}