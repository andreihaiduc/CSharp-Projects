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

namespace hangman
{
    public partial class Form1 : Form
    {
        public string cuvantAles;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                MessageBox.Show("Alegeti minim o categorie!");
                return;
            }
            else
            { 
                Random random = new Random();
                List<int> categorii = new List<int>();

                if (checkBox1.Checked) categorii.Add(1); 
                if (checkBox2.Checked) categorii.Add(2); 
                if (checkBox3.Checked) categorii.Add(3); 
                if (checkBox4.Checked) categorii.Add(4); 
                if (checkBox5.Checked) categorii.Add(5);
                int limita=0;
                int idCuvant=0;
                int categorie = categorii[random.Next(categorii.Count)];
                if (categorie == 1)
                {
                     idCuvant=random.Next(1,4);
                    limita = 4;
                }
                else if (categorie == 2) 
                {
                     idCuvant = random.Next(4, 7);
                    limita = 7;
                }
                else if(categorie == 3)
                {
                     idCuvant = random.Next(7, 10);
                    limita = 10;
                }
                else if( categorie == 4)
                {
                     idCuvant = random.Next(10, 13);
                    limita = 13;
                }
                else if(categorie==5)
                {
                     idCuvant = random.Next(13, 16); 
                    limita = 16;
                }
                try
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\cuvintebd.mdf;Integrated Security=True;Connect Timeout=30";
                    SqlConnection sqlConnection=new SqlConnection(connectionString);
                    sqlConnection.Open();
                    string comanda = "SELECT * FROM Cuvinte WHERE Id >= " + idCuvant + " and Id< " + limita + ";";
                    SqlCommand command= new SqlCommand(comanda,sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();

                   while (reader.Read())
                   {
                        if (Convert.ToInt32(reader[0])==idCuvant)
                        {
                            cuvantAles = reader[2].ToString();
                            break;
                        }
                   }
                   reader.Close();
                    sqlConnection.Close();
                    this.Hide();
                    Form2 form2= new Form2(cuvantAles,this);
                    form2.Show();
                   // MessageBox.Show(cuvantAles);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
