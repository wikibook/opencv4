using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenCvSharp.Size Cv_size = new OpenCvSharp.Size();
            System.Drawing.Size Draw_size = new System.Drawing.Size();
        }
    }
}
