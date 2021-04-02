using System;
using System.IO;
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
                        byte img = image_binary.ReadByte();
                        image[di * 784 + i] = (float)img;
                    }
                    byte lb = label_binary.ReadByte();
                    label[di] = (int)lb;
                }
                return new Tuple<float[], int[]>(image, label);
            }
        }

        static void Main(string[] args)
        {
            Tuple<float[], int[]> train = loadTrainData("./fashion-mnist/train-images-idx3-ubyte", "./fashion-mnist/train-labels-idx1-ubyte", 60000);
            Tuple<float[], int[]> test = loadTrainData("./fashion-mnist/t10k-images-idx3-ubyte", "./fashion-mnist/t10k-labels-idx1-ubyte", 10000);

            Mat train_x = new Mat(60000, 784, MatType.CV_32F, train.Item1);
            Mat train_y = new Mat(1, 60000, MatType.CV_32S, train.Item2);
            Mat test_x = new Mat(10000, 784, MatType.CV_32F, test.Item1);
            Mat test_y = new Mat(1, 10000, MatType.CV_32S, test.Item2);

            KNearest knn = KNearest.Create();
            knn.Train(train_x, SampleTypes.RowSample, train_y);

            int count = 500;
            Mat results = new Mat();
            Mat neighborResponses = new Mat();
            Mat dists = new Mat();
            int retval = (int)knn.FindNearest(test_x[0, count, 0, 784], 7, results, neighborResponses, dists);
            results.ConvertTo(results, MatType.CV_32S);

            for (int i = 0; i < count; ++i)
            {
                float[] image_array = new float[784];
                Array.Copy(test.Item1, 784 * i, image_array, 0, 784);
                Mat image = new Mat(28, 28, MatType.CV_32F, image_array);
                image.ConvertTo(image, MatType.CV_8UC1);

                Console.WriteLine($"Index : {i}");
                Console.WriteLine($"예측값 : {label_dict[results.At<int>(i)]}");
                Console.WriteLine($"실젯값 : {label_dict[test_y.At<int>(0, i)]}");
                Cv2.ImShow("image", image);
                Cv2.WaitKey();
            }
            Cv2.DestroyAllWindows();
        }
    }
}