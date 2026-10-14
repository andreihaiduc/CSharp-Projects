using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fibo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 50,y=50;
        int[]v = new int[13];

        private void Form1_Load(object sender, EventArgs e)
        {
            int a = 1, b = 1, c;
            v[1] = a;
            v[2] = b;

            int valoare = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 3; i <= 12; i++)
            {
                c = a + b;
                v[i] = c;

                a = b;   
                b = c;   
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            x = 50;
            y = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 2);
            
            int valoare = Convert.ToInt32(numericUpDown1.Value);
            Rectangle[] patrate = new Rectangle[15];

            int masura = panel1.Width / 233;

            patrate[1] = new Rectangle(700, 500, v[1] * masura, v[1] * masura);
            g.DrawRectangle(pen, patrate[1]);

            patrate[2] = new Rectangle(patrate[1].Right, patrate[1].Top, v[2] * masura, v[2] * masura);
            g.DrawRectangle(pen, patrate[2]);

            int minX = patrate[1].Left;
            int minY = patrate[1].Top;
            int maxX = patrate[2].Right;
            int maxY = patrate[1].Bottom;

            int directie = 1;

            for (int i = 3; i <= valoare; i++)
            {
                int size = v[i] * masura;

                if (directie == 0) 
                    patrate[i] = new Rectangle(maxX, minY, size, size);

                else if (directie == 1) 
                    patrate[i] = new Rectangle(minX, minY - size, size, size);

                else if (directie == 2) 
                    patrate[i] = new Rectangle(minX - size, minY, size, size);

                else if (directie == 3) 
                    patrate[i] = new Rectangle(minX, maxY, size, size);

                g.DrawRectangle(pen, patrate[i]);


                Rectangle arcRect = new Rectangle();
                int unghi = 0;

                if (directie == 0) 
                {
                    arcRect = new Rectangle(patrate[i].Left - size, patrate[i].Top - size, size * 2, size * 2);
                    unghi = 0;
                }
                else if (directie == 1) 
                {
                    arcRect = new Rectangle(patrate[i].Left - size, patrate[i].Top, size * 2, size * 2);
                    unghi = 270;
                }
                else if (directie == 2) 
                {
                    arcRect = new Rectangle(patrate[i].Left, patrate[i].Top, size * 2, size * 2);
                    unghi = 180;
                }
                else if (directie == 3) 
                {
                    arcRect = new Rectangle(patrate[i].Left, patrate[i].Top - size, size * 2, size * 2);
                    unghi = 90;
                }

                
                g.DrawArc(Pens.Red, arcRect, unghi, 90);


                if (patrate[i].Left < minX) minX = patrate[i].Left;
                if (patrate[i].Top < minY) minY = patrate[i].Top;
                if (patrate[i].Right > maxX) maxX = patrate[i].Right;
                if (patrate[i].Bottom > maxY) maxY = patrate[i].Bottom;

                directie = (directie + 1) % 4;
            }

        }
    }
}
