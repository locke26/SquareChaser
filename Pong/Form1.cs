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
        
        Rectangle player = new Rectangle(295, 200, 20, 20);
       
       
        int playerScore = 0;
        

        
        int playerSpeed = 5;        

        

        
        
        

        
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftDown = false;
        bool rightDown = false;

        
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
       
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                
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
          
            e.Graphics.FillRectangle(yellowBrush, player);
            
          
            
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {                                 
            

             
            if (upArrowDown == true && player.Y > 0)
            {
                player.Y -= playerSpeed;
            }

            if (downArrowDown == true && player.Y < this.Height - player.Height)
            {
                player.Y += playerSpeed;
            }
            if (leftDown == true && player.X > 0)
            {
                player.X -= playerSpeed;
            }
            if (rightDown == true && player.X < this.Width - player.Width)
            {
                player.X += playerSpeed;
            }
            Refresh();
            
            }
        
            
                      
        }

        
    }

