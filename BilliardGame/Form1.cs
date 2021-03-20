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
           // label3.Text = Convert.ToString(ball1.D);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball = new Ball(122F, 222F, 15F, 16f, -13f);
            timer1.Enabled = true;
        }
    }
}
