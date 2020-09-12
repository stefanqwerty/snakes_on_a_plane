using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snakes_on_a_plane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBitmap();
        }

        public void LoadBitmap()
        {
            Bitmap bitmap = new Bitmap(800, 600);
            Graphics graphics = Graphics.FromImage(bitmap);
            //int red = 0;
            //int white = 11;
            //while (white <= 600)
            //{
            //    graphics.FillRectangle(Brushes.Red, 0, red, 800, 10);
            //    graphics.FillRectangle(Brushes.White, 0, white, 800, 10);
            //    red += 20;
            //    white += 20;
            //}
            graphics.FillRectangle(Brushes.Black, 0, 0, 800, 600);
            graphics.FillRectangle(Brushes.LightGreen, 400, 300, 10, 10);
            pictureBox1.Image = bitmap;
        }
    }
}
