using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private int Verificare(Button b1,Button b2,Button b3)
        {
            if (b1.Text == "X" && b2.Text == "X" && b3.Text == "X")
                return 1;
            if (b1.Text == "0" && b2.Text == "0" && b3.Text == "0")
                return 2;
            return 0;
        }

        private int castigator()
        {
            int r;
            
            r = Verificare(button1, button2, button3);
            if (r != 0) return r;

            r = Verificare(button4, button5, button6);
            if (r != 0) return r;

            r = Verificare(button7, button8, button9);
            if (r != 0) return r;

            
            r = Verificare(button1, button4, button7);
            if (r != 0) return r;

            r = Verificare(button2, button5, button8);
            if (r != 0) return r;

            r = Verificare(button3, button6, button9);
            if (r != 0) return r;

            
            r = Verificare(button1, button5, button9);
            if (r != 0) return r;

            r = Verificare(button3, button5, button7);
            if (r != 0) return r;

            return 0;
        }
        private bool ExistaCasutaLibera()
        {
            if (button1.Text == "") return true;
            if (button2.Text == "") return true;
            if (button3.Text == "") return true;
            if (button4.Text == "") return true;
            if (button5.Text == "") return true;
            if (button6.Text == "") return true;
            if (button7.Text == "") return true;
            if (button8.Text == "") return true;
            if (button9.Text == "") return true;

            return false;
        }

        private void AI()
       {
            Random random = new Random();
            int nr = random.Next(1, 10);
            int ok = 0;
            if (!ExistaCasutaLibera())
                return;
            while (ok == 0)
            {
                nr=random.Next(1, 10);
                if (nr == 1)
                {
                    if (button1.Text == "")
                    {
                        button1.Text = "0";
                        button1.BackColor= Color.Red;
                        
                        ok = 1;
                    }
                    


                }
                else if (nr == 2)
                {
                    if (button2.Text == "")
                    {
                        button2.Text = "0";
                        button2.BackColor = Color.Red;
                        ok = 1;

                    }

                }
                else if (nr == 3)
                {
                    if (button3.Text == "")
                    {
                        button3.Text = "0";
                        button3.BackColor = Color.Red;
                        ok = 1;

                    }

                }
                else if (nr == 4)
                {
                    if (button4.Text == "")
                    {
                        button4.Text = "0";
                        button4.BackColor = Color.Red;
                        ok = 1;

                    }

                }
                else if (nr == 5)
                {
                    if (button5.Text == "")
                    {
                        button5.Text = "0";
                        button5.BackColor = Color.Red;
                        ok = 1;
                    }

                }
                else if (nr == 6)
                {
                    if (button6.Text == "")
                    {
                        button6.Text = "0";
                        button6.BackColor = Color.Red;
                        ok = 1;
                    }

                }
                else if (nr == 7)
                {
                    if (button7.Text == "")
                    {
                        button7.Text = "0";
                        button7.BackColor = Color.Red;
                        ok = 1;
                    }

                }
                else if (nr == 8)
                {
                    if (button8.Text == "")
                    {
                        button8.Text = "0";
                        button8.BackColor = Color.Red;
                        ok = 1;
                    }

                }
                else if (nr == 9)
                {
                    if (button9.Text == "")
                    {
                        button9.Text = "0";
                        button9.BackColor = Color.Red;
                        ok = 1;
                    }

                }
            }
            VerificaSfarsitJoc();
            label4.Text = "X";
        }

        private void Apasare(object sender, EventArgs e)
        {
            if (label4.Text != "X")
                return;
          

            if (sender == button1 && button1.Text == "")
            {
                button1.Text = "X";
                label4.Text = "0";
                button1.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button2 && button2.Text == "")
            {
                button2.Text = "X";
                label4.Text = "0";
                button2.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button3 && button3.Text == "")
            {
                button3.Text = "X";
                label4.Text = "0";
                button3.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button4 && button4.Text == "")
            {
                button4.Text = "X";
                label4.Text = "0";
                button4.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button5 && button5.Text == "")
            {
                button5.Text = "X";
                label4.Text = "0";
                button5.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button6 && button6.Text == "")
            {
                button6.Text = "X";
                label4.Text = "0";
                button6.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button7 && button7.Text == "")
            {
                button7.Text = "X";
                label4.Text = "0";
                button7.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button8 && button8.Text == "")
            {
                button8.Text = "X";
                label4.Text = "0";
                button8.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }
            else if (sender == button9 && button9.Text == "")
            {
                button9.Text = "X";
                label4.Text = "0";
                button9.BackColor = Color.BlueViolet;
                if (VerificaSfarsitJoc())
                {
                    label4.Text = "X";
                    return;
                }
                AI();
            }

        }
        private bool VerificaSfarsitJoc()
        {
            int win = castigator();

            if (win == 1)
            {
                MessageBox.Show("X a câștigat!");
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
                button7.BackColor = Color.White;
                button8.BackColor = Color.White;
                button9.BackColor = Color.White;
                int scor =Convert.ToInt32(label5.Text);
                scor++;
                label5.Text=Convert.ToString(scor);
                
                return true;
            }
            else if (win == 2)
            {
                MessageBox.Show("0 a câștigat!");
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
                button7.BackColor = Color.White;
                button8.BackColor = Color.White;
                button9.BackColor = Color.White;
                int scor = Convert.ToInt32(label6.Text);
                scor++;
                label6.Text = Convert.ToString(scor);
                return true;
            }
            else if (!ExistaCasutaLibera())
            {
                MessageBox.Show("Remiză!");
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
                button7.BackColor = Color.White;
                button8.BackColor = Color.White;
                button9.BackColor = Color.White;
                return true;
            }
            return false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            label5.Text = "0";
            label6.Text = "0";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
        }
    }
}
