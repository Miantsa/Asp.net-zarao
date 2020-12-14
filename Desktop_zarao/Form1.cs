using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Desktop_zarao
{
    public partial class Form1 : Form
    {
        String Path_path;
        public Form1()
        {
            InitializeComponent();
        }
        //169.254.211.115
        //192.168.42.248
        private void Form1_Load(object sender, EventArgs e)
        {
            Serveur.Init();
            textBox1.Text = IpClasse.GetIp();
            button2.Enabled = false;
            Path_path =Path.GetDirectoryName(Path.GetDirectoryName( Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            Path_path += "\\Web_Zarao\\Zarao_Dossier";
            Dossier_Serveur.Creer(Path_path);
            Dossier_Serveur.CreerEnfant("Images");
            Dossier_Serveur.CreerEnfant("Videos");
            Dossier_Serveur.CreerEnfant("Musiques");
            Dossier_Serveur.CreerEnfant("Documents");
            Dossier_Serveur.CreerEnfant("Logiciels");
           // MessageBox.Show(Path_path);   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // IpClasse.GetIp();
            if (!Serveur.Actif)
            {
                Serveur.S_Ip = textBox1.Text;
                Serveur.S_Port = int.Parse(textBox2.Text);
                if (Serveur.Lancer_Serveur() == -1)
                {
                    MessageBox.Show("Probleme lancement serveur!");
                }
                else {
                    if (Serveur.Actif) {
                        button1.Enabled = false;
                        button2.Enabled = true;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        textBox2.ReadOnly = true;
                        label3.Text = "Serveur activé";
                        label3.ForeColor = Color.Green;
                       // Console.WriteLine(Dossier_Serveur.Source);
                      /*  String[] lst = Directory.GetFiles(textBox3.Text + "\\Images");
                        foreach (var l in lst)
                            Console.WriteLine(l);*/
                    }
                }

            }
            else {
                MessageBox.Show("Serveur deja Activé");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Serveur.Actif)
            {
               // MessageBox.Show("mamono");
                Serveur.Arreter_Serveur();
                if (!Serveur.Actif) {
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    textBox2.ReadOnly = false;
                    label3.Text = "Serveur non activé";
                    label3.ForeColor = Color.Black;
                }
            }
            else {
                MessageBox.Show("Serveur deja désactiveé");
            }
           
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(@""+Path_path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = IpClasse.GetIp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
