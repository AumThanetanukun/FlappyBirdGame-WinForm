using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_Flappy_Bird_Game
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left <-150)
            {
                pipeBottom.Left = 700;
                score++;
            }

            if (pipeTop.Left < -200)
            {
                pipeTop.Left = 650;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -100)
            {
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
        }
    }
}
