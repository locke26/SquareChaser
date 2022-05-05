using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Pong
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(295, 100, 20, 20);
        Rectangle player2 = new Rectangle(295, 200, 20, 20);
        Rectangle ball = new Rectangle(580, 195, 10, 10);
        Rectangle boost = new Rectangle(580, 195, 10, 10);

        int player1Score = 0;
        int player2Score = 0;
        

        int player1Speed = 5;
        int player2Speed = 5;        

        Random rand = new Random();

        SoundPlayer point = new SoundPlayer(Properties.Resources.point);
        SoundPlayer speed = new SoundPlayer(Properties.Resources.speed);
        
        

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftDown = false;
        bool rightDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown= false;
                    break;
                case Keys.D:
                    dDown= false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                   case Keys.Left:
                        leftDown = false;
                    break;
                case Keys.Right:
                    rightDown= false;
                    break;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            e.Graphics.FillRectangle(yellowBrush, boost);
          
            
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {                                 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }
            if (aDown == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }
            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += player1Speed;
            }

             
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }
            if (leftDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }
            if (rightDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed;
            }

            if (player1.IntersectsWith(ball))
            {
                ball.X = rand.Next(10, this.Width - player1.Width);
                ball.Y = rand.Next(10, this.Height - player1.Height);
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                point.Play();               
            }
            else if (player1.IntersectsWith(boost))
            {
                boost.X = rand.Next(10, this.Width - player1.Width);
                boost.Y = rand.Next(10, this.Height - player1.Height);
                player1Speed++;
                speed.Play();
            }
            else if (player2.IntersectsWith(ball))
            {
                ball.X = rand.Next(10, this.Width - player1.Width);
                ball.Y = rand.Next(10, this.Height - player1.Height);
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                point.Play();
            }
            else if (player2.IntersectsWith(boost))
            {
                boost.X = rand.Next(10, this.Width - player1.Width);
                boost.Y = rand.Next(10, this.Height - player1.Height);
                player2Speed++;
                speed.Play();
            }
            
            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1  Wins!!";
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player  2 Wins!!";
            }

            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball.X = rand.Next(10, this.Width - player1.Width);
            ball.Y = rand.Next(10, this.Height - player1.Height);

            boost.X = rand.Next(10, this.Width - player1.Width);
            boost.Y = rand.Next(10, this.Height - player1.Height);

            player1.X = rand.Next(10, this.Width - player1.Width);
            player1.Y = rand.Next(10, this.Height - player1.Height);
            player2.X = rand.Next(10, this.Width - player1.Width);
            player2.Y = rand.Next(10, this.Height - player1.Height);
        }
    }
}
