using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        private int speed_vertical = 4;
        private int speed_hor = 4;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            gamePanel.Top = background.Bottom - (background.Bottom / 10);
            finishLabel.Visible = false;
            finishLabel.Left = (background.Width / 2) - (finishLabel.Width / 2);
            finishLabel.Top = (background.Height / 2) - (finishLabel.Height / 2);            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape){ 
                this.Close(); 
            }
            if (e.KeyCode == Keys.R) {
                finishLabel.Visible = false;
                score = 0;
                speed_vertical = 4;
                speed_hor = 4;
                gameBoll.Left = 100;
                gameBoll.Top = 100;
                result.Text = "Результат: 0";
                timer.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamePanel.Left = Cursor.Position.X - (gamePanel.Width / 2);

            gameBoll.Left += speed_hor;
            gameBoll.Top += speed_vertical;

            if (gameBoll.Left <= background.Left)
            {
                speed_hor *= -1;
            }


            if (gameBoll.Right >= background.Right)
            {
                speed_hor *= -1;
            }   


            if (gameBoll.Top <= background.Top)
            {
                speed_vertical *= -1;
            }
                

            if (gameBoll.Bottom >= background.Bottom)
            {
                finishLabel.Visible = true;
                timer.Enabled = false;
            }



            if (gameBoll.Bottom >= gamePanel.Top && gameBoll.Left <= gamePanel.Right && gameBoll.Right >= gamePanel.Left)
            {
                speed_hor += 2;
                speed_vertical += 2;
                speed_vertical *= -1;
                score += 1;
                result.Text = "Результат: " + score.ToString();
                
            }
        }

    }
}
