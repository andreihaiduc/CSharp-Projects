using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Bx = 0,By = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Bx=pictureBox1.Location.X;
            By = pictureBox1.Location.Y;
           timer1.Start();
            

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.MediumPurple, 6);
            Point p2Top = new Point(pictureBox2.Right-5, 0);
            Point p2Bottpm = new Point(pictureBox2.Right-5, pictureBox2.Bottom);
            g.DrawLine(pen, p2Top, p2Bottpm);

        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.MediumPurple, 6);
            Point p3Top = new Point(5,5);
            Point p3Bottom = new Point(5, pictureBox3.Height);
            g.DrawLine(pen, p3Top, p3Bottom);
        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.MediumPurple, 6);
            Point p4Left = new Point(0, pictureBox4.Height-5);
            Point p4Right = new Point(pictureBox4.Width, pictureBox4.Height-5);
            g.DrawLine(pen,p4Left, p4Right);    

        }

        private void pictureBox5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.MediumPurple, 6);
            Point p5Left = new Point(5,5);
            Point p5Right = new Point(pictureBox4.Width,3);
            g.DrawLine(pen, p5Left, p5Right);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                int y=pictureBox6.Location.Y;

                pictureBox6.Location=new Point (pictureBox6.Location.X,y-10);
            }

            if (e.KeyCode == Keys.S)
            {
                int y = pictureBox6.Location.Y;

                pictureBox6.Location = new Point(pictureBox6.Location.X, y + 10);
            }


            if (e.KeyCode == Keys.Up)
            {
                int y = pictureBox7.Location.Y;

                pictureBox7.Location = new Point(pictureBox7.Location.X, y - 10);
            }

            if (e.KeyCode == Keys.Down)
            {
                int y = pictureBox7.Location.Y;

                pictureBox7.Location = new Point(pictureBox7.Location.X, y + 10);
            }
        }

        int speed = 8;
        public void ResetPoz(int x, int y)
        {
            timer1.Start();
            pictureBox1.Location = new Point(Bx,By);
        }
        bool st=true;
        bool dr=false;
        int speedX = 4; 
        int speedY = 4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox6.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                pictureBox6.Top = pictureBox4.Bottom;
            }
            if(pictureBox6.Bounds.IntersectsWith (pictureBox5.Bounds))
            {
                pictureBox6.Top = pictureBox5.Top - pictureBox6.Height;
            }

            if (pictureBox7.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                pictureBox7.Top = pictureBox4.Bottom;
            }
            if (pictureBox7.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                pictureBox7.Top = pictureBox5.Top - pictureBox6.Height;
            }
            pictureBox1.Left += speedX;
            pictureBox1.Top += speedY;
            if (pictureBox1.Bounds.IntersectsWith(pictureBox6.Bounds))
            {
                speedX = Math.Abs(speedX); 
            }

            
            if (pictureBox1.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                speedX = -Math.Abs(speedX); 
            }


           
            if (pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                speedY = Math.Abs(speedY);
            }

            if (pictureBox1.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                speedY = -Math.Abs(speedY);
            }
            if(pictureBox1.Bounds.IntersectsWith( pictureBox3.Bounds))
            {
                timer1.Stop();
                int scor=Convert.ToInt32(label2.Text);
                scor++;
                label2.Text=scor.ToString();
                ResetPoz(pictureBox1.Location.X,pictureBox1.Location.Y);
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                timer1.Stop();
                int scor = Convert.ToInt32(label3.Text);
                scor++;
                label3.Text = scor.ToString();
                ResetPoz(pictureBox1.Location.X, pictureBox1.Location.Y);
            }


        }
    }
}
