using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilliardGame
{
    public partial class Form1 : Form
    {
        
        Graphics g;
        Bitmap btm;
        Graphics BtmToG;
        public Ball ball;
        SolidBrush br = new SolidBrush(Color.Blue);
        SolidBrush blueBrush = new SolidBrush(Color.Red);
        bool dragging;
        bool tension;
        RectangleF r = new RectangleF();
        Point cursor = Point.Empty;

        float x;
        float y;
        public Form1()
        {
            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            btm = new Bitmap(this.Width, this.Height);
            BtmToG = Graphics.FromImage(btm);
            
        }
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            r.X = ball.X;
            r.Y = ball.Y;
            BtmToG.Clear(Color.Green);
            ball.MoveBall();       // вычисление нового положения шара
            if(tension)
            BtmToG.DrawLine(new Pen(Color.Blue), ball.X+ball.R, ball.Y+ball.R, cursor.X, cursor.Y);
            BtmToG.FillRectangle(blueBrush, r);
            BtmToG.FillEllipse(br, ball.X, ball.Y, 2 * ball.R, 2 * ball.R);
            
            g.DrawImage(btm, Point.Empty);
            
            label1.Text = Convert.ToString(ball.X);
            label2.Text = Convert.ToString(ball.Y);
            label3.Text = tension.ToString();
            label4.Text = Convert.ToString(ball.DX);
            label5.Text = Convert.ToString(ball.DY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball = new Ball(122F, 222F, 15F, 16f, -13f);
            
            r.Width = ball.R*2;
            r.Height = ball.R*2;

            timer1.Enabled = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (r.Contains(cursor))
            {
                ball.X = r.X - cursor.X;
                ball.Y = r.Y - cursor.Y;
                ball.DX = 0F;
                ball.DY = 0F;
                tension = false;
                dragging = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            if(ball.DX==0&&ball.DY==0)
            tension = true;
            //r.Height = 30;
            //r.Width = 30;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor.X = e.X;
            cursor.Y = e.Y;
            if (dragging)
            {
                ball.X = cursor.X - ball.R;
                ball.Y = cursor.Y - ball.R;
            } 
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dragging)
            {
                ball.DX = -(e.X - ball.X)/5;
                ball.DY = -(e.Y - ball.Y)/5;
                //ball.DX = (float)Math.Sqrt(Convert.ToDouble(Math.Pow(Convert.ToDouble(), 2))); ;
                //ball.DY = (float)Math.Sqrt(Convert.ToDouble(Math.Pow(Convert.ToDouble(e.Y - ball.Y), 2)));
                tension = false;
            }
        }
    }
}
