using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FibonacciBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Label[,] matrice = new Label[10, 10];
        List<Cercs> cerc= new List<Cercs>();
        Random random = new Random();
        int pozI=0, pozJ=0;
        int ok, fals;
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview=true;
            chart1.Visible=false;
            pozI = 0;
            pozJ = 0;
            ok = 0;
            fals = 0;
            for (int i = 0; i <10; i++)
            {

                for(int  j = 0; j <10; j++)
                {
                    matrice[i, j] = new Label();

                    matrice[i, j].Width = 40;
                    matrice[i, j].Height = 40;
                    matrice[i, j].Left = j * 40;
                    matrice[i, j].Top = i * 40;
                    matrice[i, j].BackColor = Color.Transparent;
                    matrice[i, j].BorderStyle = BorderStyle.FixedSingle;
                    matrice[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    matrice[i, j].Font = new Font("Arial", 10, FontStyle.Bold);

                    matrice[i, j].Text = random.Next(1, 21).ToString();



                    int nr = Convert.ToInt32(matrice[i, j].Text);
                    if (verif(nr) == 1)
                    {
                        ok++;
                    }
                    else
                    {
                        fals++;

                    }


                    matrice[i, j].Paint += Eticheta_Paint;
                    panel1.Controls.Add(matrice[i, j]);
                }
            }
            matrice[0, 0].Text = "0";
            matrice[0,0].BackColor = Color.Transparent;
            matrice[9, 9].Text = "0";
            matrice[9,9].BackColor = Color.Red;
            Cercs cerc1 = new Cercs();
            cerc.Add(cerc1);



        }
        int[] nrfibo = { 1, 2, 3, 5, 8, 13, 21 };
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            cerc[0].DeseneazaCerc(e.Graphics);
        }
        public int latura;

       int verif(int n)
        {
            for(int i = 0;i< nrfibo.Length; i++)
            {
                if (nrfibo[i] == n)
                    return 1;
            }
            return 0;
        }


        private void Eticheta_Paint(object sender, PaintEventArgs e)
        {
            Label etichetaCurenta = (Label)sender;

           
            if (etichetaCurenta == matrice[pozI, pozJ])
            {
               
                Pen pen = new Pen(Color.Black, 3);
                Brush brush = new SolidBrush(Color.LightSeaGreen);

               
                e.Graphics.FillEllipse(brush, 5, 5, 30, 30);
                e.Graphics.DrawEllipse(pen, 5, 5, 30, 30);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            chart1.Series["Numere Fibonacci"].Points.Clear();
            chart1.Series["Numere non-Fibonacci"].Points.Clear();
            ok = 0;
            fals = 0;

            cerc.Clear();
            label2.Text = "0";
            Form1_Load(sender, e);
            panel1.Invalidate();
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            latura = 40; 

           

            if (e.KeyCode == Keys.Right)
            {
                if (cerc[0].X + latura < 10 * latura)
                {
                    cerc[0].X = cerc[0].X + latura;
                    pozJ++;
                    int nr = Convert.ToInt32(matrice[pozI, pozJ].Text);
                    if(verif(nr)==1)
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor + nr;
                        label2.Text=scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;
                    }
                    else
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor - nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;

                    }
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (cerc[0].X > 0)
                {
                    cerc[0].X = cerc[0].X - latura;
                    pozJ--;
                    int nr = Convert.ToInt32(matrice[pozI, pozJ].Text);
                    if (verif(nr) == 1)
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor + nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;
                    }
                    else
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor - nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;

                    }
                }
            }

          
            if (e.KeyCode == Keys.Down)
            {
                if (cerc[0].Y + latura < 10 * latura)
                {
                    cerc[0].Y = cerc[0].Y + latura;
                    pozI++;
                    int nr = Convert.ToInt32(matrice[pozI, pozJ].Text);
                    if (verif(nr) == 1)
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor + nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI,pozJ].BackColor = Color.White;

                    }
                    else
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor - nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;

                    }
                }
            }

           
            if (e.KeyCode == Keys.Up)
            {
                if (cerc[0].Y > 0)
                {
                    cerc[0].Y = cerc[0].Y - latura;
                    pozI--;
                    int nr = Convert.ToInt32(matrice[pozI, pozJ].Text);
                    if (verif(nr) == 1)
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor + nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;
                    }
                    else
                    {
                        int scor = Convert.ToInt32(label2.Text);
                        scor = scor - nr;
                        label2.Text = scor.ToString();
                        matrice[pozI, pozJ].Text = "0";
                        matrice[pozI, pozJ].BackColor = Color.White;

                    }

                }
            }
            if (pozI == 9f && pozJ == 9)
            {
                MessageBox.Show("Ai terminat jocul cu un scor de " + label2.Text + " puncte!\n Felicitari!");
                KeyPreview = false;
                chart1.Visible = true;
                chart1.Series["Numere Fibonacci"].Points.AddXY("Fibonacci", ok);
                chart1.Series["Numere Fibonacci"].Points.AddXY("non-Fibonacci", 0);

                chart1.Series["Numere non-Fibonacci"].Points.AddXY("Fibonacci", 0);
                chart1.Series["Numere non-Fibonacci"].Points.AddXY("non-Fibonacci", fals);
               
                return;
            }

            panel1.Invalidate();
        }
    }
}
