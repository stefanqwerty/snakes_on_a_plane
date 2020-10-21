using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace snakes_on_a_plane
{
    public partial class Form1 : Form
    {

        public int BlockSize = 20;

        bool Pause = true;

        public static Game Game = new Game();

        SoundPlayer startSound = new SoundPlayer(Game.startupPath + "\\Blip_Select.wav");

        SoundPlayer playSound = new SoundPlayer(Game.startupPath + "\\Laser_Shoot9.wav");

        int FrameNumber = 0;

        string[] CounterStrings = new string[] { "  3", "  2", "  1", "START", "" };

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
            
            if (FrameNumber < 5)
            {
                
                countdownLabel.Text = CounterStrings[FrameNumber];
                System.Threading.Thread.Sleep(800);
                FrameNumber++;

                if (FrameNumber < 4)
                {
                    startSound.Play();
                }

                if (FrameNumber == 4)
                {
                    playSound.Play();
                }
            }
            
            if (FrameNumber == 5)
            {
                countdownLabel.Visible = false;
                FrameNumber++;
            }

            if (Pause)
            {
                if (Game.NextFrame())
                {
                    Game.Snake.MoveAndGrow();

                    Draw();

                    //HeadPos.Text = Game.Snake.Head.Position.ToString();
                }
                else
                {
                    SoundPlayer deathSound = new SoundPlayer(Game.startupPath + "\\Randomize2.wav");

                    deathSound.Play();

                    Thread.Sleep(1000);
                    Application.Exit();
                }
            }
            
        }

        public void Draw()
        {
            Bitmap bitmap = new Bitmap(Convert(Game.Columns), Convert(Game.Rows));
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.FillRectangle(Brushes.Black, 0, 0, 1600, 800);
            pictureBox1.Image = bitmap;
            graphics.FillRectangle(Brushes.Red, Convert(Game.Food.Column), Convert(Game.Food.Row), BlockSize, BlockSize);
            foreach (var snakeElement in Game.Snake.GetAllSnakeElements())
            {
                graphics.FillRectangle(Brushes.Green, Convert(snakeElement.Column), Convert(snakeElement.Row), BlockSize, BlockSize);
            }
        }

        public int Convert(int GameElementPosition)
        {
            return BlockSize * GameElementPosition;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
            {
                Pause = !(Pause);
            }
    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
