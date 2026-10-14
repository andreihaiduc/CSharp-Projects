using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penalty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public List<PictureBox>targets;
        int speed = 16;
        Point destinatie;
        Random random = new Random();
        List<Image> portImages;

        Point portDest;
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            targets =new List<PictureBox> { pictureBox2, pictureBox3, pictureBox4, pictureBox5,pictureBox6 };
            portImages = new List<Image>{Properties.Resources.stand_small, Properties.Resources.right_save_small, Properties.Resources.left_save_small,Properties.Resources.top_left_save_small,Properties.Resources.top_right_save_small,Properties.Resources.top_save_small};
        }
        bool mingeaAparata = false;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox target = sender as PictureBox;
            if (target!=null)
            {
                int portIndex = random.Next(targets.Count);


                
                portDest = targets[portIndex].Location;

                
                int imgIndex = random.Next(1, portImages.Count); 
                pictureBox7.Image = portImages[imgIndex];

                portDest = targets[portIndex].Location;
                mingeaAparata = false;
                destinatie = target.Location; 
                timer1.Start();
                timer2.Start();
                pictureBox1.BringToFront(); 
            }
            DoubleBuffered = true;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x=pictureBox1.Location.X;
            int y=pictureBox1.Location.Y;
           
            Rectangle targetRect = new Rectangle(destinatie, pictureBox1.Size);
            if (!mingeaAparata&&pictureBox1.Bounds.IntersectsWith(targetRect))
            {
                mingeaAparata = true;
                pictureBox1.Location = destinatie;
                timer1.Stop();
                timer2.Stop();
                int scor = Convert.ToInt32(label3.Text);
                scor++;
                label3.Text = scor.ToString();
                pictureBox7.Image = portImages[0];
                pictureBox7.Location = new Point(458, 223);
                pictureBox1.Location = new Point(448, 422); 
                return;
            }


            if (pictureBox1.Left < destinatie.X)
                pictureBox1.Left += speed;
            else if (pictureBox1.Left > destinatie.X)
                pictureBox1.Left -= speed;

            if (pictureBox1.Top < destinatie.Y)
                pictureBox1.Top += speed;
            else if (pictureBox1.Top > destinatie.Y)
                pictureBox1.Top -= speed;
            DoubleBuffered = true;


        }
        int speedPortar = 20;
        private void timer2_Tick(object sender, EventArgs e)
        {


            int x = pictureBox7.Location.X;
            int y = pictureBox7.Location.Y;



             
            if (!mingeaAparata && pictureBox1.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                mingeaAparata = true;

                timer1.Stop();
                timer2.Stop();
                int scor=Convert.ToInt32(label4.Text);
                scor++;
                label4.Text=scor.ToString();
                pictureBox7.Image = portImages[0];
                pictureBox1.Location = new Point(448, 422);
                pictureBox7.Location = new Point(458, 223);
                return;
            }
            if (pictureBox7.Left < portDest.X)
                pictureBox7.Left += speedPortar;
            else if (pictureBox7.Left > portDest.X)
                pictureBox7.Left -= speedPortar;

            if (pictureBox7.Top < portDest.Y)
                pictureBox7.Top += speedPortar;
            else if (pictureBox7.Top > portDest.Y)
                pictureBox7.Top -= speedPortar;
            DoubleBuffered = true;


        }
    }
}
