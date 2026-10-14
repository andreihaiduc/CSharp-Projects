using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd=new Random();    
        List<string> list=new List<string>();
        List<Button> buton=new List<Button>();

        bool apasat=false;
        int secunde = 4;
        int scor = 0;
        Button primulApasat = null;
        Button alDoileaApasat = null;

        int pereche(string b1, string b2)
        {
            try 
            { 
                if (b1 == Convert.ToInt32(b2, 2).ToString()) 
                    return 1; 
            } 
            catch 
            {
                
            }
            try 
            { 
                if(b2 == Convert.ToInt32(b1, 2).ToString()) 
                    return 1; 
            } 
            catch 
            {
                
            }
            return 0;


        }
        private void Form1_Load(object sender, EventArgs e)
        {

            buton.Add(button1);
            buton.Add(button2);
            buton.Add(button3);
            buton.Add(button4);
            buton.Add(button5);
            buton.Add(button6);
            buton.Add(button7);
            buton.Add(button8);
            buton.Add(button9);
            buton.Add(button10);
            buton.Add(button11);
            buton.Add(button12);
            buton.Add(button13);
            buton.Add(button14);
            buton.Add(button15);
            buton.Add(button16);
            

            for (int i = 1; i <= 8; i++)
            {
                list.Add(i.ToString());
                list.Add(Convert.ToString(i,2));
            }
           
            list=list.OrderBy(x => rnd.Next()).ToList();
            for (int i = 0; i < buton.Count; i++)
            {
                buton[i].Text = "?";
                buton[i].Tag = list[i].ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (timer1.Enabled || b.Text != "?" || b == primulApasat) 
                return;

            b.Text = b.Tag.ToString();

            if (primulApasat == null) 
            {    primulApasat = b;
                return; 
            }

            alDoileaApasat = b;
            
            if (pereche(primulApasat.Tag.ToString(),alDoileaApasat.Tag.ToString())==1)
            {
                 scor=Convert.ToInt32(label2.Text);
                scor++;
                label2.Text = scor.ToString();
                primulApasat.Enabled = false;
                alDoileaApasat.Enabled = false;
                primulApasat = null;
                alDoileaApasat = null;
                if(scor==8)
                {
                    MessageBox.Show("Felicitari!");
                    return;
                }
            }
            else 
                timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (apasat==true&&secunde>0)
            {                
                secunde--;
                
            }
            else
            {

                timer1.Stop();
                if (primulApasat != null)
                    primulApasat.Text = "?";
                if (alDoileaApasat != null) 
                    alDoileaApasat.Text = "?";
                primulApasat = null;
                alDoileaApasat = null;
            }
               
        }
    }
}
