using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciBlocks
{
    internal class Cercs
    {

        public Cercs() 
        {


        }
        public int X;
        public int Y;

        public void DeseneazaCerc(Graphics g)
        {
          
            Pen pen = new Pen(Color.Black, 3);
            Brush brush = new SolidBrush(Color.LightSeaGreen);
            g.FillEllipse(brush, X+5, Y+5, 30, 30);
            g.DrawEllipse(pen, X+5, Y+5, 30, 30);
        }
    }
}
