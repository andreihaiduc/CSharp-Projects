using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        bool stanga=false;
        bool dreapta=false;
        bool sus=false;
        bool cheie=false;
        bool upApasat = false;

        int vede = 1;
        
        

        int jump = 0;
        int gravity = 2;
        int scor = 0;

        int speedX = 10;
        int bspeedX = 8;

        string textScor="";


        Image marioDreapta;
        Image marioStanga;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            pictureBox19.Parent = pictureBox1;


            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            pictureBox4.Parent = pictureBox1;
            pictureBox5.Parent = pictureBox1;
            pictureBox6.Parent = pictureBox1;
            pictureBox7.Parent = pictureBox1;
            pictureBox8.Parent = pictureBox1;
            pictureBox9.Parent = pictureBox1;
            pictureBox10.Parent = pictureBox1;
            pictureBox11.Parent = pictureBox1;
            pictureBox12.Parent = pictureBox1;
            pictureBox13.Parent = pictureBox1;
            pictureBox14.Parent = pictureBox1;
            pictureBox15.Parent = pictureBox1;
            pictureBox16.Parent = pictureBox1;
            pictureBox17.Parent = pictureBox1; 
            pictureBox18.Parent = pictureBox1;

            pictureBox20.Parent = pictureBox1;
            pictureBox21.Parent = pictureBox1;
            pictureBox22.Parent = pictureBox1;
            pictureBox23.Parent = pictureBox1;
            pictureBox24.Parent = pictureBox1;
            pictureBox25.Parent = pictureBox1;
            pictureBox26.Parent = pictureBox1;
            pictureBox27.Parent = pictureBox1;
            pictureBox28.Parent = pictureBox1;
            pictureBox29.Parent = pictureBox1;
            pictureBox30.Parent = pictureBox1;
            pictureBox31.Parent= pictureBox1;
            pictureBox32.Parent = pictureBox1;
            pictureBox33.Parent = pictureBox1;
            pictureBox34.Parent = pictureBox1;
            pictureBox35.Parent = pictureBox1;
            pictureBox36.Parent = pictureBox1;
            pictureBox37.Parent = pictureBox1;
            pictureBox38.Parent = pictureBox1;
            pictureBox39.Parent = pictureBox1;
            pictureBox40.Parent = pictureBox1;
            pictureBox41.Parent = pictureBox1;
            pictureBox42.Parent = pictureBox1;
            pictureBox43.Parent = pictureBox1;
            pictureBox44.Parent = pictureBox1;
            pictureBox45.Parent = pictureBox1;
            pictureBox46.Parent = pictureBox1;
            pictureBox47.Parent = pictureBox1;
            pictureBox48.Parent = pictureBox1;
            pictureBox49.Parent = pictureBox1;
            pictureBox50.Parent = pictureBox1;
            pictureBox51.Parent = pictureBox1;
            pictureBox52.Parent = pictureBox1;
            pictureBox53.Parent = pictureBox1;


            marioDreapta = (Image)pictureBox19.Image.Clone();

            marioStanga = (Image)pictureBox19.Image.Clone();
            marioStanga.RotateFlip(RotateFlipType.RotateNoneFlipX);

            pictureBox19.Image = marioDreapta;

            ImageAnimator.Animate(pictureBox19.Image, this.frame);
           timer1.Start();
        }

        public void frame(object sender, EventArgs e)
        {
           
            this.Invalidate();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textScor = "Score: " + scor;

            pictureBox19.Top = pictureBox19.Top + jump;

            if (sus == true)
            {
                jump = jump + gravity;
            }
            else
            {
                jump = 12;
            }

            if (stanga==true&&pictureBox19.Left>10)
            {
                pictureBox19.Left = pictureBox19.Left - speedX;
            }
            if(dreapta==true&&pictureBox19.Right< pictureBox1.Width - 10)
            {
                pictureBox19.Left=pictureBox19.Left + speedX;
            }
            if(stanga==true&&pictureBox1.Left<0)
            {
                pictureBox1.Left=pictureBox1.Left+bspeedX;
                miscaretot("dreapta");
            }
            if(dreapta==true&&pictureBox1.Left> -(pictureBox1.Width - this.ClientSize.Width)+10)
            {
                pictureBox1.Left = pictureBox1.Left-bspeedX;
                miscaretot("stanga");
            }

            if(pictureBox19.Top>700)
            {
                
                timer1.Stop();
                MessageBox.Show("Game Over!");
                return;

            }



            foreach(Control x in pictureBox1.Controls)
            {
                if (x == pictureBox2 || x == pictureBox3 || x == pictureBox4 || x == pictureBox5 || x == pictureBox6 || x == pictureBox7 || x == pictureBox8 || x == pictureBox8 || x == pictureBox9 || x == pictureBox10 || x == pictureBox11 || x == pictureBox12 || x == pictureBox13 || x == pictureBox14 || x == pictureBox15 || x == pictureBox16)
                {
                    if (pictureBox19.Bounds.IntersectsWith(x.Bounds) && jump >= 0)
                    {
                        pictureBox19.Top = x.Top - pictureBox19.Height;
                        sus = false;
                        jump = 0;
                    }
                }
                else if(x==pictureBox18)
                {
                    if (pictureBox19.Bounds.IntersectsWith(pictureBox18.Bounds))
                    {
                        
                       
                        cheie= true;
                        if(cheie==true)
                        {
                            pictureBox18.Visible = false;
                            pictureBox17.Image = Properties.Resources.bluedor;
                        }
                    }
                }
                else if(x==pictureBox17)
                {
                    if (pictureBox19.Bounds.IntersectsWith(pictureBox17.Bounds))
                    {
                        timer1.Stop();
                        MessageBox.Show("Hooray! You finished the game!");
                    }
                }
                else if(x!=pictureBox19)
                {
                    if (pictureBox19.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        scor++;
                        label2.Text = scor.ToString();
                    }
                }
                
            }
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                stanga = true;
                dreapta = false;

                if (vede == 1)
                {
                    vede = 0;
                    pictureBox19.Image = Properties.Resources.e61a65e7b63871eefdc208a138ccafc9_ezgif_com_rotate;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                dreapta = true;
                stanga = false;

                if (vede == 0)
                {
                    vede = 1;
                    pictureBox19.Image = Properties.Resources.e61a65e7b63871eefdc208a138ccafc9_ezgif_com_gif_maker;
                }
            }
            if (e.KeyCode == Keys.Up && sus == false && upApasat == false)
            {

                sus = true;
                jump = -18;
            }
            

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                stanga = false;
            }
            if(e.KeyCode== Keys.Right)
            {
                dreapta = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                upApasat = false;
            }


        }

        private void miscaretot(string directie)
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x!=pictureBox19 && x!=pictureBox1)
                {
                    if(directie=="stanga")
                    {
                        x.Left = x.Left - bspeedX;
                    }
                    if(directie=="dreapta")
                    {
                        x.Left =x.Left+ bspeedX;
                    }
                }
            }
        }
    }
}
