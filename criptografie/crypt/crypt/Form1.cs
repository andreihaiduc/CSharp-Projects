using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int caesar = 5; 
        char []cuvant = new char[101];

        char[,] matrice = new char[7, 7];
        string key ="";
        char[] cuvant2 = new char[101];

        string cuvsemi="";

        string decrypt = "";
        char[] cuvantRSA = new char[101];

        int a = 0, b = 0, phi = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Introduceti un text!");
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                cuvant = textBox1.Text.ToCharArray();
                for (int i = 0; i < cuvant.Length; i++)
                {
                    if (cuvant[i] >= 'a' && cuvant[i] <= 'z')
                    {
                        cuvant[i] = (char)('a' + (cuvant[i] - 'a' + caesar) % 26);
                    }
                    else if (cuvant[i] >= 'A' && cuvant[i] <= 'Z')
                    {
                        cuvant[i] = (char)('A' + (cuvant[i] - 'A' + caesar) % 26);
                    }
                }
                MessageBox.Show(new string(cuvant));
                textBox1.Text = new string(cuvant);
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\text.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(new string(cuvant) + "\n");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {

                string caractere = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random rnd = new Random();

                char[] v = caractere.ToCharArray();

                for (int i = 0; i < v.Length; i++)
                {
                    int j = rnd.Next(v.Length);
                    char aux = v[i];
                    v[i] = v[j];
                    v[j] = aux;
                }

                int k = 0;
                matrice[0, 0] = ' ';
                matrice[0, 1] = 'A';
                matrice[0, 2] = 'D';
                matrice[0, 3] = 'F';
                matrice[0, 4] = 'G';
                matrice[0, 5] = 'V';
                matrice[0, 6] = 'X';

                matrice[1, 0] = 'A';
                matrice[2, 0] = 'D';
                matrice[3, 0] = 'F';
                matrice[4, 0] = 'G';
                matrice[5, 0] = 'V';
                matrice[6, 0] = 'X';
                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        matrice[i, j] = v[k];
                        k++;
                    }
                }

                string path2 = AppDomain.CurrentDomain.BaseDirectory + @"\cifrulADFGVX\matrice.txt";
                using (StreamWriter writer = new StreamWriter(path2, false))
                {


                    for (int i = 0; i <= 6; i++)
                    {
                        for (int j = 0; j <= 6; j++)
                        {
                            writer.Write(matrice[i, j] + " ");
                        }
                        writer.WriteLine();
                    }
                }

                string path3 = AppDomain.CurrentDomain.BaseDirectory + @"\cifrulADFGVX\keyword.txt";
                using (StreamReader reader = new StreamReader(path3))
                {
                    key = reader.ReadLine();
                    key = key.ToUpper();
                }
                cuvsemi = "";
                textBox1.Text = textBox1.Text.ToUpper();
                cuvant2 = textBox1.Text.ToCharArray();

                for (int i = 0; i < cuvant2.Length; i++)
                {
                    char c = cuvant2[i];
                    for (int j = 1; j <= 6; j++)
                    {
                        for (int h = 1; h <= 6; h++)
                        {
                            if (c == matrice[j, h])
                            {
                                cuvsemi += matrice[j, 0].ToString();
                                cuvsemi += matrice[0, h].ToString();
                            }
                        }
                    }
                }
                int linii = cuvsemi.Length / key.Length + 10;
                int coloane = key.Length;
                int lit = 0;
                char[,] mat = new char[linii, coloane];
                for (int i = 0; i < key.Length; i++)
                {
                    mat[0, i] = key[i];
                }
                for (int i = 1; i < linii; i++)
                {
                    for (int j = 0; j < coloane; j++)
                    {
                        if (lit < cuvsemi.Length)
                        {
                            mat[i, j] = cuvsemi[lit];
                            lit++;
                        }
                        else
                            mat[i, j] = '-';
                    }
                }

                for (int i = 0; i < coloane - 1; i++)
                {
                    for (int j = i + 1; j < coloane; j++)
                    {
                        if (mat[0, i] > mat[0, j])
                        {
                            for (int r = 0; r < linii; r++)
                            {
                                char aux = mat[r, i];
                                mat[r, i] = mat[r, j];
                                mat[r, j] = aux;
                            }
                        }
                    }
                }

                string Final = "";

                for (int j = 0; j < coloane; j++)
                {
                    for (int i = 1; i < linii; i++)
                    {
                        if (mat[i, j] != '-')
                        {
                            Final += mat[i, j];
                        }
                    }
                }

                MessageBox.Show(Final);
                textBox1.Text = Final;
                string path4 = AppDomain.CurrentDomain.BaseDirectory + @"\cifrulADFGVX\criptat.txt";
                using (StreamWriter writer1 = new StreamWriter(path4, true))
                {
                    writer1.WriteLine(Final + "\n");
                }

            }
            if (comboBox1.SelectedIndex == 2)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\RSA\start.txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    string linie = reader.ReadLine();

                    if (linie != null)
                    {
                        string[] detalii = linie.Split(',');

                        a = Convert.ToInt32(detalii[0]);      
                        b = Convert.ToInt32(detalii[1]);      
                        phi = Convert.ToInt32(detalii[2]);   
                    }
                }
                cuvantRSA =textBox1.Text.ToCharArray();

                Dictionary<char, int> alfabet = new Dictionary<char, int>();
                Dictionary<int, char> alfabetInvers = new Dictionary<int, char>();

                for (char c = 'A'; c <= 'Z'; c++)
                {
                    int nr = c - 'A' + 1;

                    alfabet.Add(c, nr);
                    alfabetInvers.Add(nr, c);
                }

                string text = textBox1.Text.ToUpper();
                string rezultat = "";

                for (int i = 0; i < text.Length; i++)
                {
                    char litera = text[i];

                    if (alfabet.ContainsKey(litera))
                    {
                        int m = alfabet[litera];

                        int criptat = (int)(Math.Pow(m, a) % b);

                        if (alfabetInvers.ContainsKey(criptat))
                        {
                            rezultat += alfabetInvers[criptat];
                        }
                    }
                }

                textBox1.Text = rezultat;
                MessageBox.Show(rezultat);

                string path5 = AppDomain.CurrentDomain.BaseDirectory + @"\RSA\rezultat.txt";

                using (StreamWriter writer = new StreamWriter(path5, true))
                {
                    writer.WriteLine(rezultat + "\n");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text=textBox1.Text.ToUpper();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            decrypt=textBox1.Text;
            if(comboBox1.SelectedIndex==0)
            {
                for (int i = 0; i < cuvant.Length; i++)
                {
                    if (cuvant[i] >= 'a' && cuvant[i] <= 'z')
                    {
                        cuvant[i] = (char)('a' + (cuvant[i] - 'a' - caesar) % 26);
                    }
                    else if (cuvant[i] >= 'A' && cuvant[i] <= 'Z')
                    {
                        cuvant[i] = (char)('A' + (cuvant[i] - 'A' - caesar) % 26);
                    }
                }
                textBox1.Text=new string(cuvant);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                decrypt = textBox1.Text.ToUpper();

                int coloane = key.Length;

                int randuriText = decrypt.Length / coloane;
                if (decrypt.Length % coloane != 0)
                {
                    randuriText++;
                }

                int rest = decrypt.Length % coloane;
                if (rest == 0)
                {
                    rest = coloane;
                }

                int[] ordine = new int[coloane];

                for (int i = 0; i < coloane; i++)
                {
                    ordine[i] = i;
                }

                for (int i = 0; i < coloane - 1; i++)
                {
                    for (int j = i + 1; j < coloane; j++)
                    {
                        if (key[ordine[i]] > key[ordine[j]])
                        {
                            int aux = ordine[i];
                            ordine[i] = ordine[j];
                            ordine[j] = aux;
                        }
                    }
                }

                char[,] mat = new char[randuriText, coloane];

                int p = 0;

                for (int poz = 0; poz < coloane; poz++)
                {
                    int colOriginala = ordine[poz];

                    int lungimeColoana;

                    if (colOriginala < rest)
                    {
                        lungimeColoana = randuriText;
                    }
                    else
                    {
                        lungimeColoana = randuriText - 1;
                    }

                    for (int i = 0; i < lungimeColoana; i++)
                    {
                        mat[i, colOriginala] = decrypt[p];
                        p++;
                    }
                }

                string cuvsemiDecriptat = "";

                for (int i = 0; i < randuriText; i++)
                {
                    for (int j = 0; j < coloane; j++)
                    {
                        if (mat[i, j] != '\0')
                        {
                            cuvsemiDecriptat += mat[i, j];
                        }
                    }
                }

                string textInitial = "";

                for (int i = 0; i < cuvsemiDecriptat.Length; i += 2)
                {
                    char rand = cuvsemiDecriptat[i];
                    char coloana = cuvsemiDecriptat[i + 1];

                    int linieMatrice = -1;
                    int coloanaMatrice = -1;

                    for (int r = 1; r <= 6; r++)
                    {
                        if (matrice[r, 0] == rand)
                        {
                            linieMatrice = r;
                        }
                    }

                    for (int c = 1; c <= 6; c++)
                    {
                        if (matrice[0, c] == coloana)
                        {
                            coloanaMatrice = c;
                        }
                    }

                    if (linieMatrice != -1 && coloanaMatrice != -1)
                    {
                        textInitial += matrice[linieMatrice, coloanaMatrice];
                    }
                }

                textBox1.Text = textInitial;
                MessageBox.Show(textInitial);

            }
            if(comboBox1.SelectedIndex==2)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"\RSA\start.txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    string linie = reader.ReadLine();

                    if (linie != null)
                    {
                        string[] detalii = linie.Split(',');

                        a = Convert.ToInt32(detalii[0]);      // e
                        b = Convert.ToInt32(detalii[1]);      // n
                        phi = Convert.ToInt32(detalii[2]);    // phi
                    }
                }

                int cheieDecriptare = 1;

                while ((a * cheieDecriptare) % phi != 1)
                {
                    cheieDecriptare++;
                }

                Dictionary<char, int> alfabet = new Dictionary<char, int>();
                Dictionary<int, char> alfabetInvers = new Dictionary<int, char>();

                for (char lit = 'A'; lit <= 'Z'; lit++)
                {
                    int nr = lit - 'A' + 1;

                    alfabet.Add(lit, nr);
                    alfabetInvers.Add(nr, lit);
                }

                string text = textBox1.Text.ToUpper();
                string rezultat = "";

                for (int i = 0; i < text.Length; i++)
                {
                    char litera = text[i];

                    if (alfabet.ContainsKey(litera))
                    {
                        int m = alfabet[litera];

                        int decriptat = (int)(Math.Pow(m, cheieDecriptare) % b);

                        if (alfabetInvers.ContainsKey(decriptat))
                        {
                            rezultat += alfabetInvers[decriptat];
                        }
                    }
                }

                textBox1.Text = rezultat;
                MessageBox.Show(rezultat);
            }
        }
    }
}
