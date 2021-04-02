using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OpenCvSharp;
using OpenCvSharp.ML;


namespace Project
{
    class Program
    {
        static Dictionary<int, string> label_dict = new Dictionary<int, string>()
        {
            { 0, "T-shirt/top" },
            { 1, "Trouser" },
            { 2, "Pullover" },
            { 3, "Dress" },
            { 4, "Coat" },
            { 5, "Sandal" },
            { 6, "Shirt" },
            { 7, "Sneaker" },
            { 8, "Bag" },
            { 9, "Ankle boot" }
        };

        static Tuple<float[], int[]> loadTrainData(string image_path, string label_path, int length)
        {
            using (FileStream image_data = new FileStream(image_path, FileMode.Open))
            using (FileStream label_data = new FileStream(label_path, FileMode.Open))
            using (BinaryReader image_binary = new BinaryReader(image_data))
            using (BinaryReader label_binary = new BinaryReader(label_data))
            {
                image_binary.ReadBytes(16);
                label_binary.ReadBytes(8);

                float[] image = new float[length * 784];
                int[] label = new int[length];

                for (int di = 0; di < length; ++di)
                {
                    for (int i = 0; i < 784; ++i)
                    {
                        float img = image_binary.ReadByte();
                        image[di * 784 + i] = (float)img;
                    }
                    byte lb = label_binary.ReadByte();
                    label[di] = (int)lb;
                }
                return new Tuple<float[], int[]>(image, label);
            }
        }

        static float[] HogCompute(float[] images)
        {
            HOGDescriptor hog = new HOGDescriptor(new Size(28, 28), new Size(8, 8), new Size(4, 4), new Size(4, 4), 9, 1, -1, HistogramNormType.L2Hys, 0.2, true, 28);
            List<float[]> descriptor = new List<float[]>();

            for (int num = 0; num < images.Length / 784; num++)
            {
                float[] image_array = new float[784];
                Array.Copy(images, 784 * num, image_array, 0, 784);
                Mat image = new Mat(28, 28, MatType.CV_32F, image_array);
                image.ConvertTo(image, MatType.CV_8UC1);
                descriptor.Add(hog.Compute(image));
            }

            List<float> flatten_descriptor = (from list in descriptor from item in list select item).ToList();
            return flatten_descriptor.ToArray();
        }

        static void Main(string[] args)
        {
            Tuple<float[], int[]> train = loadTrainData("./fashion-mnist/train-images-idx3-ubyte", "./fashion-mnist/train-labels-idx1-ubyte", 60000);
            Tuple<float[], int[]> test = loadTrainData("./fashion-mnist/t10k-images-idx3-ubyte", "./fashion-mnist/t10k-labels-idx1-ubyte", 10000);

            float[] train_descriptor = HogCompute(train.Item1);
            float[] test_descriptor = HogCompute(test.Item1);

            Mat train_x = new Mat(60000, train_descriptor.Length / 60000, MatType.CV_32F, train_descriptor);
            Mat train_y = new Mat(1, 60000, MatType.CV_32S, train.Item2);
            Mat test_x = new Mat(10000, test_descriptor.Length / 10000, MatType.CV_32F, test_descriptor);
            Mat test_y = new Mat(1, 10000, MatType.CV_32S, test.Item2);

            SVM svm = SVM.Create();
            svm.Type = SVM.Types.CSvc;
            svm.KernelType = SVM.KernelTypes.Rbf;
            svm.Gamma = 0.5;
            svm.C = 0.5;
            svm.Train(train_x, SampleTypes.RowSample, train_y);

            int count = 500;
            Mat results = new Mat();
            svm.Predict(test_x[0, count, 0, test_x.Width], results);
            results.ConvertTo(results, MatType.CV_32S);

            Mat matches = new Mat();
            Cv2.Compare(results, test_y[0, 1, 0, count].T(), matches, CmpType.EQ);
            Console.WriteLine((float)Cv2.CountNonZero(matches) / count * 100);
        }
    }
}