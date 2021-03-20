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
        bool dragging;
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
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
        }
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            BtmToG.Clear(Color.Green);
            ball.MoveBall();       // вычисление нового положения шара
            BtmToG.FillEllipse(br, ball.X, ball.Y, 2 * ball.R, 2 * ball.R);
            g.DrawImage(btm, Point.Empty);
            
            label1.Text = Convert.ToString(ball.X);
            label2.Text = Convert.ToString(ball.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball = new Ball(122F, 222F, 10F, 16f, -13f);
            r.X = ball.X;
            r.Y = ball.Y;
            r.Width = ball.R;
            r.Height = ball.R;

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
                dragging = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            r.Height = 30;
            r.Width = 30;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor.X = e.X;
            cursor.Y = e.Y;
            if (dragging)
            {
                r.X = cursor.X + ball.X;
                r.Y = cursor.Y + ball.Y;
            }
            
        }
    }
}
