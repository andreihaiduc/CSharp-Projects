using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form2 : Form
    {
        public string cuvantAles;
        public Form1 form1;
        int desene = 0;
        int gameover = 0;
        public Form2(string cuvantAles,Form1 form1)
        {
            InitializeComponent();
            this.cuvantAles = cuvantAles;
            this.form1=form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show(cuvantAles);


            int x = 0; 
            int y = 10; 
            int width = 30; 
            int height = 50; 
            int spacing = 5;
            for (int i = 0; i < cuvantAles.Length; i++)
            {
                TextBox tb = new TextBox();
                tb.ReadOnly = true;
            
                tb.Width = width;
                tb.Height = height;
                tb.Location = new Point(x + i * (width + spacing), y);
                tb.Name = i.ToString();
                panel2.Controls.Add(tb);

            }

           
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            char literaApasata = btn.Text[0]; 
            btn.Visible = false;

           
            bool amGasitLitera = false;
            for (int i = 0; i < cuvantAles.Length; i++)
            {
                if (cuvantAles[i] == literaApasata)
                {
                    amGasitLitera = true;
                    
                    if (panel2.Controls.ContainsKey(i.ToString()))
                    {
                        TextBox tb = panel2.Controls[i.ToString()] as TextBox;
                        if (tb != null)
                        {
                            tb.Text = literaApasata.ToString();
                            gameover++;

                        }
                    }
                }
            }
            if(gameover==cuvantAles.Length)
            {
                MessageBox.Show("Felicitari!");
                System.Environment.Exit(0);
            }
            if(amGasitLitera == false && desene<=5)
            {
                if (desene == 0)
                {
                    Graphics g = panel1.CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 3;
                    Rectangle rectangle = new Rectangle(140, 140, 50, 40);
                    g.DrawEllipse(pen, rectangle);
                    desene++;
                    return;
                }
                else if(desene==1)
                {
                    Graphics g = panel1.CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 3;
                    g.DrawLine(pen,165, 180, 165, 300);
                    desene++;
                    return;

                }
                if(desene == 2)
                {
                    Graphics g = panel1.CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 3;
                    g.DrawLine(pen, 165, 230, 120, 170);
                    desene++;
                    return;
                }
                if(desene==3)
                {
                    Graphics g = panel1.CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 3;
                    g.DrawLine(pen, 165, 230, 210, 170);
                    desene++;
                    return;
                }
                if(desene==4)
                {
                    Graphics g = panel1.CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 3;
                    g.DrawLine(pen, 165, 300, 120, 330);
                    desene++;
                    return;
                }
                if(desene==5)
                {
                    Graphics g = panel1.CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    pen.Width = 3;
                    g.DrawLine(pen, 165, 300, 210, 330);
                    MessageBox.Show("Ai pierdut!");
                    System.Environment.Exit(0);
                }
            }
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, 300, 100, 30, 250);
            g.DrawRectangle(pen, 300, 100, 30, 250);

            g.FillRectangle(brush, 150, 100, 175, 20);
            g.DrawRectangle(pen, 150, 100, 175, 20);

            g.FillRectangle(brush, 150, 120, 20, 20);
            g.DrawRectangle(pen, 150, 120, 20, 20);
        }
    }
}
