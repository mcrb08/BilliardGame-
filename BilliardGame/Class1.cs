using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardGame
{
    public class GameField : Form1
    {
        protected int BorederWidth = 10;
    }
   public class Ball : GameField
    {
         public float X { get; set;}
         public float Y { get; set;}
         public float R { get; set; }
        public float DX { get; set;}
        public float DY { get; set;}
        public  Ball(float x, float y, float r, float dx, float dy)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
            this.DX = dx;
            this.DY = dy;
        }

        public void MoveBall()
        {
            if (X >= Form1.ActiveForm.ClientSize.Width - 2 * R)
                DX = -DX;
            if(X<0)
                DX = -DX;
            X += DX;
            DX *= 0.99F;
            if ( Math.Abs(DX) < 0.01F)
                DX = 0;
            if (Y >= Form1.ActiveForm.ClientSize.Height - 2 * R)
                DY = -DY;
            if (Y < 0)
                DY = -DY;
            Y += DY;
            DY *= 0.99F;
            if (Math.Abs(DY) < 0.01F)
                DY = 0;
        }

    }
}
