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

namespace eboi
{
    public partial class Form1 : Form
    {
        int b1 = 0, b11 = 0;
        int b2 = 0, b21 = 0;
        int b3 = 0, b31 = 0;
        int b4 = 0, b41 = 0;

        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = Properties.Resources.yo;
            this.Icon = Properties.Resources.happy;
            pictureBox1.BackColor = Color.White;
            pictureBox2.BackColor = Color.White;
            pictureBox3.BackColor = Color.White;
            pictureBox4.BackColor = Color.White;          
        }

        private void ChangeStatusStrip(dynamic s)
        {
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(s);
        }

        private void DrawCircle(int x, int y, int width, int height, Graphics graphic)
        {
            Pen pen = new Pen(Color.Red, 5);
            Graphics circle = graphic;
            circle.DrawEllipse(pen, x, y, width, height);
        }
        private void DrawCircleLoop(int x, int y, int maxDiameter, Graphics graphic)
        {
            int i = 0;
            while (true)
            {
                for (; i <= maxDiameter; ++i)
                {
                    DrawCircle(x, y, i, i, graphic);
                    Thread.Sleep(50);
                    graphic.Clear(Color.White);
                }
                for (; i >= 0; --i)
                {
                    DrawCircle(x, y, i, i, graphic);
                    Thread.Sleep(50);
                    graphic.Clear(Color.White);
                }
            }
            
        }
        private void DrawCircleLoopThread(dynamic o)
        { 
            DrawCircleLoop(o[0], o[1], o[2], o[3]);
        }

        private void StartStop1_Click(object sender, EventArgs e)
        {
            if (b11 == 0)
            {
                StartStop1.Text = "Stop";
                t1 = new Thread(DrawCircleLoopThread);
                Graphics g1 = pictureBox1.CreateGraphics();
                dynamic[] lol = { pictureBox1.Width / 2 - 40, pictureBox1.Height / 2 - 40, 85, g1 };
                t1.Start(lol);
                b11 = 1;
                b1 = 1;
                ChangeStatusStrip("Thread 1 was started. ");
                rofl1.BackColor = Color.Green;
                Graphics kek = rofl1.CreateGraphics();
            }
            else if (b1 == 0)
            {              
                StartStop1.Text = "Stop";
                t1.Resume();
                b1 = 1;
                ChangeStatusStrip("Thread 1 was resumed. ");
                rofl1.BackColor = Color.Green;
            }
            else if (b1 == 1)
            {
                
                t1.Suspend();
                b1 = 0;
                StartStop1.Text = "Start";
                ChangeStatusStrip("Thread 1 was stopped. ");
                rofl1.BackColor = Color.Red;
            }
        }

        private void DrawXYC(dynamic g)
        {      
            Pen GreenPen;
            GreenPen = new Pen(Color.Green);

            Point Centr;
            int centrX = pictureBox2.Width;
            int centrY = pictureBox2.Height; 
            Centr = new Point(centrX / 2, centrY / 2);

            Point KX1, KX2;
            KX1 = new Point(0, centrY / 2);
            KX2 = new Point(centrX, centrY / 2);
            g.DrawLine(GreenPen, KX1, KX2);

            Point KY1, KY2;
            KY1 = new Point(centrX / 2, 0);
            KY2 = new Point(centrX / 2, centrY);

            g.DrawLine(GreenPen, KY1, KY2);
        }
        private void DrawSinX(int cx, int cy, int cw, Graphics g)
        {
            while (true)
            {
                PointF[] p1 = new PointF[cx];
                for (int i = 0; i < cx; ++i)
                {
                    p1[i].X = i;
                    p1[i].Y = (float)((cy / 2) * (1 - Math.Sin(i * cw * Math.PI / (cx - 1))));

                    DrawXYC(g);
                    g.DrawLines(Pens.Red, p1);

                    Thread.Sleep(10);

                    g.Clear(Color.White);
                }
                p1 = null;
                PointF[] p2 = new PointF[cx];
                for (int i = cx - 1; i >= 0; --i)
                {
                    p2[i].X = i;
                    p2[i].Y = (float)((cy / 2) * (1 - Math.Sin(i * cw * Math.PI / (cx - 1))));

                    DrawXYC(g);
                    g.DrawLines(Pens.Red, p2);

                    Thread.Sleep(10);

                    g.Clear(Color.White);
                }
                p2 = null;
            }
        }
        private void DrawSinXThread(dynamic o)
        {
            DrawSinX(o[0], o[1], o[2], o[3]);
        }  

        private void StartStop2_Click(object sender, EventArgs e)
        {
            labelSin.Visible = true;
            if (b21 == 0)
            {
                StartStop2.Text = "Stop";
                t2 = new Thread(DrawSinXThread);
                Graphics g2 = pictureBox2.CreateGraphics();
                dynamic[] lol = { pictureBox2.Width, pictureBox2.Height, 8, g2 };
                t2.Start(lol);
                b21 = 1;
                b2 = 1;
                ChangeStatusStrip("Thread 2 was started. ");
                rofl2.BackColor = Color.Green;
            }
            else if (b2 == 0)
            {
                StartStop2.Text = "Stop";
                t2.Resume();
                b2 = 1;
                ChangeStatusStrip("Thread 2 was resumed. ");
                rofl2.BackColor = Color.Green;
            }
            else if (b2 == 1)
            {
                t2.Suspend();
                b2 = 0;
                StartStop2.Text = "Start";
                ChangeStatusStrip("Thread 2 was stopped. ");
                rofl2.BackColor = Color.Red;
            }
        }

        private void DrawCosX(int cx, int cy, int cw, Graphics g)
        {
            while (true)
            {
                PointF[] p1 = new PointF[cx];
                for (int i = 0; i < cx; ++i)
                {
                    p1[i].X = i;
                    p1[i].Y = (float)((cy / 2) * (1 - Math.Cos(i * cw * Math.PI / (cx - 1))));

                    DrawXYC(g);
                    g.DrawLines(Pens.Red, p1);

                    Thread.Sleep(10);

                    g.Clear(Color.White);
                }
                p1 = null;
                PointF[] p2 = new PointF[cx];
                for (int i = cx - 1; i >= 0; --i)
                {
                    p2[i].X = i;
                    p2[i].Y = (float)((cy / 2) * (1 - Math.Cos(i * cw * Math.PI / (cx - 1))));

                    DrawXYC(g);
                    g.DrawLines(Pens.Red, p2);

                    Thread.Sleep(10);

                    g.Clear(Color.White);
                }
                p2 = null;
            }
        }
        private void DrawCosXThread(dynamic o)
        {
            DrawCosX(o[0], o[1], o[2], o[3]);
        }

        private void StartStop3_Click(object sender, EventArgs e)
        {
            labelCos.Visible = true;
            if (b31 == 0)
            {
                StartStop3.Text = "Stop";
                t3 = new Thread(DrawCosXThread);
                Graphics g3 = pictureBox3.CreateGraphics();
                dynamic[] lol = { pictureBox3.Width, pictureBox3.Height, 8, g3 };
                t3.Start(lol);
                b31 = 1;
                b3 = 1;
                ChangeStatusStrip("Thread 3 was started. ");
                rofl3.BackColor = Color.Green;
            }
            else if (b3 == 0)
            {
                StartStop3.Text = "Stop";
                t3.Resume();
                b3 = 1;
                ChangeStatusStrip("Thread 3 was resumed. ");
                rofl3.BackColor = Color.Green;
            }
            else if (b3 == 1)
            {
                t3.Suspend();
                b3 = 0;
                StartStop3.Text = "Start";
                ChangeStatusStrip("Thread 3 was stopped. ");
                rofl3.BackColor = Color.Red;
            }
            
        }

        private void Func4Rofl(dynamic g)
        {
            Random random = new Random();
            int height = pictureBox4.Height;
            int width = pictureBox4.Width;

            Pen pen = new Pen(Color.Green, 2);

            int v = 2; 
            double x = random.Next(30, width - 30);  
            double y = random.Next(30, height - 30);  
            double a = random.Next(0, 360);   

            double vx = v * Math.Cos(a);     
            double vy = v * Math.Sin(a);

            while (true)
            {
                g.DrawEllipse(new Pen(Color.White, 2), Convert.ToInt32(Math.Round(x)), Convert.ToInt32(Math.Round(y)), 30, 30);

                x += vx; 
                y += vy;

                if (x < 1)
                {
                    vx = -vx;
                }
                if (x > width - 30)
                {
                    vx = -vx;  
                }
                if (y < 1)
                {
                    vy = -vy;
                }
                if (y > height - 30)
                {
                    vy = -vy;
                }

                g.DrawEllipse(pen, Convert.ToInt32(Math.Round(x)), Convert.ToInt32(Math.Round(y)), 30, 30);
                Thread.Sleep(10);
            }
        }

        private void StartStop4_Click(object sender, EventArgs e)
        {
            if (b41 == 0)
            {
                StartStop4.Text = "Stop";
                t4 = new Thread(Func4Rofl);
                Graphics g4 = pictureBox4.CreateGraphics();
                t4.Start(g4);
                b41 = 1;
                b4 = 1;
                ChangeStatusStrip("Thread 4 was started. ");
                rofl4.BackColor = Color.Green;
            }
            else if (b4 == 0)
            {
                StartStop4.Text = "Stop";
                t4.Resume();
                b4 = 1;
                ChangeStatusStrip("Thread 4 was resumed. ");
                rofl4.BackColor = Color.Green;
            }
            else if (b4 == 1)
            {
                t4.Suspend();
                b4 = 0;
                StartStop4.Text = "Start";
                ChangeStatusStrip("Thread 4 was stopped. ");
                rofl4.BackColor = Color.Red;
            }
        }
    }
}
