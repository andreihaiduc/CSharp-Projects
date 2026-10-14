using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractali
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        Random rnd=new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            int pasi = (int)numericUpDown1.Value;

            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);

            Point point1 = new Point(panel1.Width / 2, 0);
            Point point2 = new Point(0, panel1.Height);
            Point point3 = new Point(panel1.Width, panel1.Height);

            Point[] points = { point1, point2, point3 };

            g.DrawPolygon(pen, points);
            DeseneazaSierpinski(g, pen, pasi, point1, point2, point3);

        }
        private void DeseneazaSierpinski(Graphics g, Pen pen, int pasi, Point point1, Point point2, Point point3)
        {
            if(pasi==0)
                return;
            Point mijloc12 = new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);
            Point mijloc23 = new Point((point2.X + point3.X) / 2, (point2.Y + point3.Y) / 2);
            Point mijloc13 = new Point((point1.X + point3.X) / 2, (point1.Y + point3.Y) / 2);
            Point[] points = { mijloc12,mijloc23,mijloc13 };
            int culoare1=rnd.Next(0,256);
            int culoare2=rnd.Next(0,256);
            int culoare3=rnd.Next(0,256);
            SolidBrush brush = new SolidBrush(Color.FromArgb(culoare1,culoare2,culoare3));
            g.FillPolygon(brush,points);
            g.DrawPolygon(pen, points);

            DeseneazaSierpinski(g, pen, pasi - 1, point1, mijloc12, mijloc13);
            DeseneazaSierpinski(g,pen, pasi-1, mijloc12,point2, mijloc23);
            DeseneazaSierpinski(g, pen, pasi - 1, mijloc13, mijloc23, point3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();

            int pasi = (int)numericUpDown1.Value;

            Graphics g=panel1.CreateGraphics();

            Pen pen = new Pen(Color.Black);

            int cX = panel1.Width / 2;
            int cY = panel1.Height / 2;

            int lg = panel1.Width / 2;

            ArboreH(g,pen, pasi,cX, cY,lg);
           
        }

        private void ArboreH(Graphics g,Pen pen, int pasi, int x, int y, int lg)
        {
            if (pasi == 0 || lg <= 0)
                return;

            int mij = lg / 2;

            Point stmij= new Point(x - mij, y);
            Point drmij = new Point(x + mij, y);
            g.DrawLine(pen, stmij, drmij);


            Point stSUS = new Point(x - mij, y - mij);
            Point stJOS = new Point(x - mij, y + mij);
            g.DrawLine(pen, stSUS, stJOS);

            Point drSUS = new Point(x + mij, y - mij);
            Point drJOS = new Point(x + mij, y + mij);
            g.DrawLine(pen, drSUS, drJOS);

            int lg2= lg / 2;

            ArboreH(g, pen, pasi-1, stSUS.X, stSUS.Y, lg2);
            ArboreH(g, pen, pasi - 1, stJOS.X, stJOS.Y, lg2);
            ArboreH(g,pen,pasi-1, drSUS.X, drSUS.Y,lg2);
            ArboreH(g,pen,pasi-1,drJOS.X, drJOS.Y,lg2);
        }
    }
}
