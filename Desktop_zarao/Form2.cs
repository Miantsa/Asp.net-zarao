using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Desktop_zarao
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean test = false;
            SQLiteCommand cmd = new SQLiteCommand("select * from Administrateur;", Base.Req());
            try {
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (textBox1.Text == reader["Pseudo"].ToString() && Crypto.Crypt_mot(textBox2.Text) == reader["Mdp"].ToString()) {
                        test = true;
                    }
                   // Console.WriteLine(reader["Pseudo"]);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            if (test)
            {
                this.Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else {
                MessageBox.Show("Erreur utilisateur ou Mot de passe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            cmd.Dispose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
