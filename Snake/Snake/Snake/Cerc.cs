using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    internal class Cerc
    {
        public int X;
        public int Y;
        public Color Culoare;
        public int Marime;
        public Cerc(int x,int y,int marime,Color culaore)
        {
            X = x;
            Y = y; 
            Culoare = culaore;
            Marime = marime;
        }

        public void deseneazaCerc(Graphics g)
        {
            Brush brush1 = new SolidBrush(Culoare);
            Pen pen = new Pen(Color.Black);
           
            g.FillEllipse(brush1, X , Y , Marime, Marime);
            g.DrawEllipse(pen, X, Y , Marime, Marime);

        }

    }
}
