using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // pictureBox1 생성과 Form Load 이벤트 생성
        private void Form1_Load(object sender, EventArgs e)
        {   
            // 파란색 이미지 생성
            Mat mat_image = Mat.Zeros(new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height), MatType.CV_8UC3);
            mat_image.SetTo(Scalar.LightBlue);

            // 비트맵 변환
            Bitmap bitmap_image = mat_image.ToBitmap();
            pictureBox1.Image = bitmap_image;
        }
    }
}
