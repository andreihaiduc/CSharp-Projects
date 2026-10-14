using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox4.Location = new Point(151, 36);
            

        }
        int speed = 16;
        bool mLEFT = false;
        bool mRIGHT = false;
       
        int []nr=new int[10];
        Image[] masini = { Properties.Resources.TruckWhite, Properties.Resources.TruckBlue, Properties.Resources.carGreen, Properties.Resources.ambulance, Properties.Resources.carYellow, Properties.Resources.CarRed };
        Random random = new Random();
        int[] viteze = new int[6];
        PictureBox[] obstacole = new PictureBox[6];
        Image[] premiu = { Properties.Resources.bronze, Properties.Resources.silver, Properties.Resources.gold }; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top=pictureBox1.Top + speed;
            pictureBox2.Top=pictureBox2.Top + speed;
            int scor=Convert.ToInt32(label2.Text);
            scor++;
            label2.Text = scor.ToString();
            if (pictureBox1.Top >= this.ClientSize.Height)
            {
                pictureBox1.Top = pictureBox2.Top - pictureBox1.Height;
                

            }
            if (pictureBox2.Top >= this.ClientSize.Height)
            {
                pictureBox2.Top = pictureBox1.Top - pictureBox2.Height;

            }
            
           

        }
        private void cadMasini(int index)
        {
            PictureBox pic = obstacole[index];

            pic.Top = pic.Top + viteze[index];

            if (pic.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                pictureBox1.SendToBack();
                pictureBox2.SendToBack();
                
                int scor=Convert.ToInt32(label2.Text);
                if(scor<=500)
                {
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox5.Location=pictureBox3.Location;
                    pictureBox4.Image = premiu[0];
                  
                }
                if(scor>=500&&scor<1000)
                {
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox5.Location = pictureBox3.Location;
                    pictureBox4.Image = premiu[1];
                   
                   

                }
                if(scor>1000)
                {
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox5.Location = pictureBox3.Location;
                    pictureBox4.Image = premiu[2];
                    
                }
               timer4.Start();

            }
            else if (pic.Top > this.ClientSize.Height)
            {
                reset(index);
            }
        }
        
        private void reset(int index)
        {
            PictureBox pic = obstacole[index];
            pic.Image= masini[index];
            pic.Top = random.Next(-2500, -250);
            pic.Left = random.Next(0, this.ClientSize.Width - pic.Width);

           
            viteze[index] = random.Next(5, 10);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label2.Text = "0";
            for (int i = 0; i < masini.Length; i++)
            {
                reset(i);
            }

            pictureBox4.Location = new Point(151, 36);

            timer2.Start();
            timer1.Start();
            timer3.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox4.Visible=false;
            label2.Text = "0";
            pictureBox1.Location = new Point(0, 0);
            
            for (int i = 0; i < obstacole.Length; i++)
            {
                obstacole[i] = new PictureBox(); 
                obstacole[i].Image = masini[i];
                this.Controls.Add(obstacole[i]);
                obstacole[i].SizeMode = PictureBoxSizeMode.AutoSize;
                obstacole[i].BringToFront();
                reset(i);
            }
           


            pictureBox2.Location = new Point(0, -pictureBox1.Height);
           
           
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(mLEFT==true&&pictureBox3.Left>0)
            {
                pictureBox3.Left = pictureBox3.Left - speed;
               
            }
            if(mRIGHT==true&& pictureBox3.Right < this.ClientSize.Width)
            {
                pictureBox3.Left = pictureBox3.Left + speed;
            }
        }
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                mLEFT = true;
               
            }
            if (e.KeyCode == Keys.D)
            {
                mRIGHT = true;
               
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                mLEFT = false;
                
            }
            if (e.KeyCode == Keys.D)
            {
                mRIGHT = false;
                
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            for(int i = 0;i<masini.Length;i++)
            {
                cadMasini(i);
            }
        }
        int i = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {

            if (i > 10)
            {
                timer4.Stop();
                i = 0;
                pictureBox4.Location = new Point(151, 36);


            }
            pictureBox4.Location = new Point(pictureBox4.Location.X, pictureBox4.Location.Y + i);
                i++;
            
            
        }
    }
}
