using System;
using System.Drawing;
using System.Windows.Forms;

namespace snakes_on_a_plane
{
    public partial class Form1 : Form
    {
        public string WhichDirection;
        public int BlockSize = 20;

        Game Game = new Game();

        public Form1()
        {
            InitializeComponent();
            LoadBitmap();
        }

        public void LoadBitmap()
        {
            int lenght = 1600;
            int width = 800;
            int centerLine = lenght / 2;
            int centerRow = width / 2;
            Bitmap bitmap = new Bitmap(lenght, width);
            Graphics graphics = Graphics.FromImage(bitmap);
           
            graphics.FillRectangle(Brushes.Black, 0, 0, 1600, 800);
            //graphics.FillRectangle(Brushes.LightGreen, 400, 300, 10, 10);
            pictureBox1.Image = bitmap;
            HeadPos.Text = Game.Snake.Head.position.column.ToString() + " , " + Game.Snake.Head.position.row.ToString();
            graphics.FillRectangle(Brushes.Red, convert(Game.Snake.Food.Position.row), convert(Game.Snake.Food.Position.column), 20, 20);
            var temp = Game.Snake.Head;
            while(temp.next != null)
            {
                graphics.FillRectangle(Brushes.Green, convert(temp.position.row), convert(temp.position.column), 20, 20);
                temp = temp.next;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Game.NextFrame())
            {
                if (WhichDirection == "right")
                {
                    if (Game.Snake.TryChangeDirection(Snake.Direction.Right))
                    {
                        Game.Snake.direction = Snake.Direction.Right;
                    }
                }
                if (WhichDirection == "down")
                {
                    if (Game.Snake.TryChangeDirection(Snake.Direction.Down))
                    {
                        Game.Snake.direction = Snake.Direction.Down;
                    }
                }
                if (WhichDirection == "left")
                {
                    if (Game.Snake.TryChangeDirection(Snake.Direction.Left))
                    {
                        Game.Snake.direction = Snake.Direction.Left;
                    }
                }
                if (WhichDirection == "up")
                {
                    if (Game.Snake.TryChangeDirection(Snake.Direction.Up))
                    {
                        Game.Snake.direction = Snake.Direction.Up;
                    }
                }

                Game.Snake.Move(Game.Snake.direction);

                LoadBitmap();
            }
            else
            {
                Application.Exit();
            }
        }

        public int convert(int GameElementPosition)
        {
            return BlockSize * GameElementPosition;
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
