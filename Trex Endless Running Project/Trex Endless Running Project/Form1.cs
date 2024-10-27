using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace Trex_Endless_Running_Project
{
    public partial class Form1 : Form
    {
        Image backgroundImage;
        Image backgroundImage2;

        int backgroundWidth;
        int backgroundHeight;

        int bgPositionX = 0;
        int bgPositionY = 0;
        int bg2PositionX = 0;
        int obstaclesSpeed = 12;

        int formWidth;
        int attackTimer = 0;
        int attackR = 0;
        int score = 0;
        int speed = 10;

        int[] flyingPosition = { 290, 260, 290, 260 };

        bool jumping = false;
        bool changeAnim = false;
        bool flyingAttack = false;
        bool gameover = false;

        Random random = new Random();

        List<PictureBox> obstacles = new List<PictureBox>();
        PictureBox hitBox = new PictureBox();

        PrivateFontCollection newFont = new PrivateFontCollection();

        SoundPlayer HitSound;
        SoundPlayer jumpSound;

        Button Restart;
        Button Exit;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            GameSetUp();
            Reset();

            newFont.AddFontFile("Font/pixel.ttf");

            Restart = new Button();
            Restart.Text = "Restart";
            Restart.Size = new Size(120, 60);
            Restart.Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2 - 70);
            Restart.Visible = false;
            Restart.Click += btnRestart_Click;
            Restart.BackColor = Color.LightGray;
            Restart.ForeColor = Color.Black;
            Restart.Font = new Font(newFont.Families[0], 11, FontStyle.Bold);

            Exit = new Button();
            Exit.Text = "Exit";
            Exit.Size = new Size(120, 60);
            Exit.Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2);
            Exit.Visible = false;
            Exit.Click += btnExit_Click;
            Exit.BackColor = Color.LightGray;
            Exit.ForeColor = Color.Black;
            Exit.Font = new Font(newFont.Families[0], 11, FontStyle.Bold);

            this.Controls.Add(Restart);
            this.Controls.Add(Exit);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (!gameover)
            {
                if (e.KeyCode == Keys.Up && !jumping)
                {
                    jumping = true;
                    jumpSound = new SoundPlayer("C:\\Users\\tranh\\source\\repos\\Trex Endless Running Project\\Trex Endless Running Project\\Audio\\Jump.wav");
                    jumpSound.Play();
                }
                if (e.KeyCode == Keys.Down && !jumping)
                {
                    if (changeAnim == false)
                    {
                        Trex.Image = Properties.Resources.Running; 
                        changeAnim = true;
                    }
                    Trex.Top = 320;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && !gameover)
            {
                Trex.Image = Properties.Resources.Running;
                Trex.Top = 290;
                changeAnim = false;
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(backgroundImage, bgPositionX, bgPositionY, backgroundWidth, backgroundHeight);
            Canvas.DrawImage(backgroundImage2, bg2PositionX, bgPositionY, backgroundWidth, backgroundHeight);

            Canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            MoveBackGrounds();
            MoveObstacles();

            this.Invalidate();


            lblScore.Text = "Score: " + score;

            hitBox.Left = Trex.Right - (hitBox.Width + 20);
            hitBox.Top = Trex.Top + 5;

            if (jumping)
            {
                Trex.Top -= speed;

                if (Trex.Top < 150)
                {
                    speed = -10;
                }
                if (Trex.Top > 290)
                {
                    jumping = false;
                    Trex.Top = 290;
                    speed = 10;
                }
            }

            foreach (PictureBox x in obstacles)
            {
                if (x.Bounds.IntersectsWith(hitBox.Bounds))
                {
                    GameTimer.Stop();
                    Trex.Image = Properties.Resources.Lose;
                    gameover = true;
                    HitSound = new SoundPlayer("C:\\Users\\tranh\\source\\repos\\Trex Endless Running Project\\Trex Endless Running Project\\Audio\\End.wav");
                    HitSound.Play();
                    Trex.Top = 290;

                    Restart.Visible = true;
                    Exit.Visible = true;
                }
            }
        }

        private void GameSetUp()
        {
            backgroundWidth = 1000;
            backgroundHeight = 440;
            bg2PositionX = 1000;

            backgroundImage = Properties.Resources.BGPixel;
            backgroundImage2 = Properties.Resources.BGPixel;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            formWidth = this.ClientSize.Width;
            this.BackColor = Color.Black;
            obstacles.Add(obstacles1);
            obstacles.Add(obstacles2);
            obstacles.Add(obstacles3);

            obstacles1.Top = 290; 
            obstacles2.Top = 290;
            obstacles3.Top = flyingPosition[random.Next(flyingPosition.Length)];

            newFont.AddFontFile("Font/pixel.ttf");
            lblScore.Font = new Font(newFont.Families[0], 30, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Text = "Score: 0";

            hitBox.BackColor = Color.Transparent;
            hitBox.Width = Trex.Width / 2;
            hitBox.Height = Trex.Height - 10;

            this.Controls.Add(hitBox);
            //hitBox.BringToFront();
            gameover = false;

            attackR = random.Next(12, 20);
        }

        private void Reset()
        { 
            Trex.Image = Properties.Resources.Running;
            Trex.Top = 290;

            int alignedPositionY = 290;

            obstacles1.Left = formWidth + random.Next(100, 200);
            obstacles2.Left = obstacles1.Left + random.Next(600, 800);
            obstacles3.Left = obstacles1.Left + random.Next(400, 600);

            obstacles1.Top = alignedPositionY + 30;
            obstacles2.Top = alignedPositionY + 10;
            obstacles3.Top = alignedPositionY;

            GameTimer.Start();
            score = 0;
            attackTimer = 0;
            speed = 10;

            gameover = false;
            changeAnim = false;
            jumping = false;

            obstaclesSpeed = 10;
        }

        private void MoveBackGrounds()
        {
            bgPositionX -= 5;
            bg2PositionX -= 5;

            if (bgPositionX < -backgroundWidth)
            {
                bgPositionX = bg2PositionX + backgroundWidth;
            }

            if (bg2PositionX < -backgroundWidth)
            {
                bg2PositionX = bgPositionX + backgroundWidth;
            }
        }

        private void MoveObstacles()
        {
            if (!flyingAttack)
            {
                obstacles1.Left -= obstaclesSpeed;
                obstacles2.Left -= obstaclesSpeed;
            }
            else
            {
                obstacles3.Left -= obstaclesSpeed;
            }

            if (attackTimer == attackR)
            {
                flyingAttack = true; ;
                attackR = random.Next(12, 20);
            }

            if (attackTimer == 0)
            {
                flyingAttack = false;
            }

            if (obstacles1.Left < -100)
            {
                obstacles1.Left = obstacles2.Left + obstacles2.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;
            }
            if (obstacles2.Left < -100)
            {
                obstacles2.Left = obstacles1.Left + obstacles1.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;
            }
            if (obstacles3.Left < -100)
            {
                obstacles3.Left = formWidth + random.Next(300, 400);
                obstacles3.Top = flyingPosition[random.Next(flyingPosition.Length)];
                attackTimer -= 1;
                score += 1;
            }
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            Reset();
            Restart.Visible = false;
            Exit.Visible = false;

            GameTimer.Start();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
