using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Click_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int scorCurent = 0;
        int scorMaxim = 0;
        int nrVerziActive = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                string connectionString  = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bazadtt.mdf;Integrated Security=True;Connect Timeout=30";

                SqlConnection connection=new SqlConnection(connectionString);
                connection.Open();

                string commandTXT = "SELECT * FROM Punctaj";
                
                SqlCommand comanda=new SqlCommand(commandTXT, connection);
                SqlDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    
                    label2.Text = reader[1].ToString();
                    scorMaxim = Convert.ToInt32(reader[1].ToString()); 

                }
                    connection.Close();          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PictureBox_Click(object sender, EventArgs e)
        {

            PictureBox currentPictureBox = (PictureBox)sender;
            if(scorCurent>0&&(scorCurent+1)%5==0)
            {
                timer1.Interval = timer1.Interval / 2;
            }
            if (currentPictureBox.BackColor == Color.Green)
            {
                scorCurent++;
                nrVerziActive--;
            }
            else if(currentPictureBox.BackColor == Color.Red)
            { 
                scorCurent--;
                
            }
            label1.Text =  scorCurent.ToString();

                this.Controls.Remove(currentPictureBox);
        }




       private void pictureBox1_Click(object sender, EventArgs e)
        {
            
           
        }
       



        Random random = new Random();




        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int culorePoza = random.Next(0, 2);
            PictureBox pictureBox = new PictureBox();
            int x = random.Next(100, this.ClientSize.Width-30);
            int y = random.Next(100, this.ClientSize.Height-30);
            pictureBox.Location = new Point(x,y);
            pictureBox.Width = 30;
            pictureBox.Height = 30;
            if(nrVerziActive>10||scorCurent<-9)
            {
                timer1.Stop();
                pictureBox2.Visible = true;
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bazadtt.mdf;Integrated Security=True;Connect Timeout=30";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string commandTXT = "SELECT * FROM Punctaj"; 
                SqlCommand comanda = new SqlCommand(commandTXT, connection);

                SqlDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    scorMaxim = Convert.ToInt32(reader[1]);
                }
                reader.Close(); 
                
     
                    
                    if(scorMaxim<scorCurent)
                    {
                        string cmd = "UPDATE Punctaj SET ScorMAXIM = "+scorCurent;
                        SqlCommand comanda1 = new SqlCommand(cmd, connection);
                        comanda1.ExecuteNonQuery();
                    }

                
                
                
                 

                connection.Close();
                return;

            }
            if (culorePoza == 0)
            {
                pictureBox.BackColor = Color.Red;
            }
            else if (culorePoza == 1)
            {
                pictureBox.BackColor = Color.Green;
                nrVerziActive++;
            }
            this.Controls.Add(pictureBox);

            pictureBox.Click += PictureBox_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Pe ecran apar patrate rosii si verzi.\nTrebuie sa dai click pe cele verzi pentru ca scorul sa creasca cu 1.\nDaca dai click pe rosu, scorul scade cu 1.\nLa fiecare scor multiplu de 5, viteza se dubleaza!\nJocul se incheie cand sunt cel putin 10 patratele verzi pe ecran.");
            timer1.Start();
        }
    }
}
