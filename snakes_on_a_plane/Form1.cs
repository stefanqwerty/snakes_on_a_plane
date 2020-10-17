using System;
using System.Drawing;
using System.Windows.Forms;

namespace snakes_on_a_plane
{
    public partial class Form1 : Form
    {

        public string WhichDirection;
        public int BlockSize = 20;

        public Game Game = new Game();

        public Form1()
        {
            InitializeComponent();
            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _ = (e.KeyCode switch
            {
                Keys.Down => Game.Snake.TryChangeDirection(Direction.Down),
                Keys.Up => Game.Snake.TryChangeDirection(Direction.Up),
                Keys.Left => Game.Snake.TryChangeDirection(Direction.Left),
                Keys.Right => Game.Snake.TryChangeDirection(Direction.Right),
                _ => true
            });
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Game.NextFrame())
            {
                Game.Snake.MoveAndGrow();

                Draw();

                HeadPos.Text = Game.Snake.Head.Position.ToString();
            }
            else
            {
                //Application.Exit();
            }
        }

        public void Draw()
        {
            Bitmap bitmap = new Bitmap(Convert(Game.Columns), Convert(Game.Rows));
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.Black, 0, 0, 1600, 800);
            pictureBox1.Image = bitmap;
            graphics.FillRectangle(Brushes.Red, Convert(Game.Food.Row), Convert(Game.Food.Column), BlockSize, BlockSize);
            foreach (var snakeElement in Game.Snake.GetAllSnakeElements())
            {
                graphics.FillRectangle(Brushes.Green, Convert(snakeElement.Row), Convert(snakeElement.Column), BlockSize, BlockSize);
            }
        }

        public int Convert(int GameElementPosition)
        {
            return BlockSize * GameElementPosition;
        }
    }
}
