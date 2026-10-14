using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        List<Cerc> cercs = new List<Cerc>();
        bool jocInceput = false;
        int scorMax = 0;
        int scorActual;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(cercs.Count>0)
            {
                cercs[0].deseneazaCerc(e.Graphics);
                for (int i = 0; i < cercs.Count; i++)
                    cercs[i].deseneazaCerc(e.Graphics);
            }
            
            if (jocInceput)
            {
                Brush redBrush = Brushes.Red;
                e.Graphics.FillEllipse(redBrush, marX, marY, 15, 15);
                Pen pen = Pens.Black;
                e.Graphics.DrawEllipse(pen,marX, marY, 15, 15); 
            }
        }
        
        void StartJoc()
        {
            cercs.Clear();
            label3.Text = "0";
            int marime = 15;
            int x = (pictureBox1.Width / 2 / marime) * marime;
            int y = (pictureBox1.Height / 2 / marime) * marime;

            cercs.Add(new Cerc(x, y, marime, Color.Black));

            dx = 15;
            dy = 0;
            mere();
             jocInceput = true;
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = false;
            pictureBox1.Invalidate();
        }
        
        int marX, marY;

        public void mere()
        {
            Random random = new Random();
            int marime = 15;
            marX = random.Next(0, pictureBox1.Width / marime) * marime;
            marY = random.Next(0, pictureBox1.Height / marime) * marime;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "0";
            if(scorMax>Convert.ToInt32(label4.Text))
            {
                label4.Text = scorMax.ToString();
            }
            Random random = new Random();
           
            int marime = 15;

            int x = (pictureBox1.Width / 2 / marime) * marime;
            int y = (pictureBox1.Height / 2 / marime) * marime;

            cercs.Add(new Cerc(x, y, marime, Color.Black));
           
          
            pictureBox1.Invalidate();
        }
        int dx = 15, dy = 0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            
           


            for (int i = cercs.Count - 1; i > 0; i--)
            {
                cercs[i].X = cercs[i - 1].X;
                cercs[i].Y = cercs[i - 1].Y;
            }
            cercs[0].X += dx;
            cercs[0].Y += dy;

            for (int i = 1; i < cercs.Count; i++)
            {
                if (cercs[0].X == cercs[i].X && cercs[0].Y == cercs[i].Y)
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over! Ai muscat corpul!");
                    if (scorMax > Convert.ToInt32(label4.Text))
                    {
                        label4.Text = scorMax.ToString();
                        
                    }
                    label3.Text = "0";
                        scorActual = 0;
                        scorMax = 0;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    return;
                }
            }




            if (cercs[0].X == marX && cercs[0].Y == marY)
            {
                mere();
                scorActual++;
                label3.Text=scorActual.ToString();
                Cerc ult = cercs[cercs.Count - 1];
                Random rnd=new Random();
                Color culoareRandom = Color.FromArgb(rnd.Next(0,256),rnd.Next(0,256),rnd.Next(0,256));
                cercs.Add(new Cerc(ult.X, ult.Y, 15, culoareRandom));
                if(scorMax<scorActual)
                    scorMax=scorActual;
                pictureBox1.Invalidate();

            }

            
            if (cercs[0].X < 0 || cercs[0].Y < 0 || cercs[0].X+15 > pictureBox1.Width || cercs[0].Y+15 > pictureBox1.Height)
            {
                timer1.Stop();
                MessageBox.Show("Game Over! Ai iesit din gradina!");
                if (scorMax > Convert.ToInt32(label4.Text))
                {
                    label4.Text = scorMax.ToString();
                   
                }
                label3.Text = "0";
                scorActual = 0;
                scorMax = 0;
                button1.Enabled = true;
                button2.Enabled = true;
                return;
            }
            

            pictureBox1.Invalidate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rectangle r = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

            pictureBox1.DrawToBitmap(bmp, r);


            saveFileDialog1.Title = "Salvare imagine";

            saveFileDialog1.DefaultExt = ".png";
            Graphics g = Graphics.FromImage(bmp);
            Brush brush = Brushes.Black;
            Font Font = new Font("Arial", 12, FontStyle.Bold);
            g.DrawString("Score: " + label3.Text,Font,brush, 0, 0);
            g.DrawString("HighScore: " + label4.Text, Font, brush, 0, 30);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string cale = saveFileDialog1.FileName;
                bmp.Save(cale);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            StartJoc();
            mere();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && dy == 0)
            {
                dx = 0;
                dy = -15;
            }
            else if (e.KeyCode == Keys.Down && dy == 0)
            {
                dx = 0;
                dy = 15;
            }
            else if (e.KeyCode == Keys.Left && dx == 0)
            {
                dx = -15;
                dy = 0;
            }
            else if (e.KeyCode == Keys.Right && dx == 0)
            {
                dx = 15;
                dy = 0;
            }
        }
    }
}
