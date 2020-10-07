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
        public string WhichDirection;
        public int BlockSize = 20;

        public Form1()
        {
            InitializeComponent();
            LoadBitmap();
            initiateBitmap();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBitmap();
        }

        Game Game = new Game();

        public void initiateBitmap()
        {
            Bitmap bitmap = new Bitmap(1600, 800);
        }

        public void LoadBitmap()
        {
            int lenght = 1600;
            int width = 800;
            int centerRow = lenght / 2;
            int centerLine = width / 2;
            Bitmap bitmap = new Bitmap(lenght, width);
            Graphics graphics = Graphics.FromImage(bitmap);
            var colourPen = new Pen(Brushes.DarkGreen);
           
            graphics.FillRectangle(Brushes.Black, 0, 0, 1600, 800);
            //graphics.FillRectangle(Brushes.LightGreen, 400, 300, 10, 10);
            pictureBox1.Image = bitmap;
            //HeadPos.Text = Game.Snake.Head.position.column.ToString() + " , " + Game.Snake.Head.position.row.ToString();
            graphics.FillRectangle(Brushes.Green, Game.Snake.Head.position.row, Game.Snake.Head.position.column, 20, 20);
            graphics.FillRectangle(Brushes.Red, Game.Snake.Food.Position.row, Game.Snake.Food.Position.column, 20, 20);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Game.NextFrame())
            {
                if (WhichDirection == "right")
                {
                    Game.Snake.direction = Snake.Direction.Right;
                }
                if (WhichDirection == "down")
                {
                    Game.Snake.direction = Snake.Direction.Down;
                }
                if (WhichDirection == "left")
                {
                    Game.Snake.direction = Snake.Direction.Left;
                }
                if (WhichDirection == "up")
                {
                    Game.Snake.direction = Snake.Direction.Up;
                }

                Game.Snake.Move(Game.Snake.direction);

                LoadBitmap();
            }
            else
            {
                Application.Exit();
            }
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                WhichDirection = "down";
            }
            if (e.KeyCode == Keys.Left)
            {
                WhichDirection = "left";
            }
            if (e.KeyCode == Keys.Up)
            {
                WhichDirection = "up";
            }
            if (e.KeyCode == Keys.Right)
            {
                WhichDirection = "right";
            }
        }
    }
}
