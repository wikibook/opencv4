using System;
using OpenCvSharp;


namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("egg.jpg");
            Mat data = new Mat();
            src.Reshape(3, src.Width * src.Height).ConvertTo(data, MatType.CV_32FC3);

            int K = 7;
            Mat bestLabels = new Mat();
            Mat centers = new Mat();
            double retval = Cv2.Kmeans(data, K, bestLabels, TermCriteria.Both(10, 0.001), 10, KMeansFlags.RandomCenters, centers);

            Mat<int> bestLabels3b = new Mat<int>(bestLabels);
            MatIndexer<int> bestLabelsIndexer = bestLabels3b.GetIndexer();

            centers.ConvertTo(centers, MatType.CV_8UC3);
            Mat<Vec3b> centers3b = new Mat<Vec3b>(centers);
            MatIndexer<Vec3b> centersIndexer = centers3b.GetIndexer();

            int idx = 0;
            Mat dst = new Mat(new Size(src.Width, src.Height), MatType.CV_8UC3);
            Mat<Vec3b> dst3b = new Mat<Vec3b>(dst);
            MatIndexer<Vec3b> dstIndexer = dst3b.GetIndexer();

            for (int y = 0; y < dst.Height; y++)
            {
                for (int x = 0; x < dst.Width; x++)
                {
                    int clusterIdx = bestLabelsIndexer[idx];
                    Vec3b color = centersIndexer[clusterIdx];
                    dstIndexer[y, x] = color;
                    idx++;
                }
            }

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}