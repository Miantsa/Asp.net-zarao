using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Desktop_zarao
{
    public partial class Form3 : Form
    {
        private String InputFile;
        private String DecryptDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())))+"\\Web_Zarao\\Zarao_Dossier";
        private String CryptDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) + "\\Web_Zarao\\Zarao_Dossier_Cryptage";
        private String password = "miniproj";
        private String InputDir;
        private String OutputDir;
        private Boolean erreur = false;
        List<String> liste;
        private Boolean boolImage = false;
        private Boolean boolVideo = false;
        private Boolean boolMusique = false;
        private Boolean boolDocument = false;
        private Boolean boolLogiciel = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                String filename = openFileDialog1.FileName;
                if (filename != null) {
                    textBox1.Text = filename;
                    InputFile = filename;
                    FileInfo fi=new FileInfo(filename);
                    if (fi.Extension == ".zrc")
                    {
                        btnCryptage.Enabled = false;
                        btnDecryptage.Enabled = true;
                    }
                    else {
                        btnCryptage.Enabled = true;
                        btnDecryptage.Enabled = false;
                    }
                   // MessageBox.Show(fi.DirectoryName);
                    textBox2.Text = "";
                }
            
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bgCryptage.WorkerReportsProgress = true; bgCryptAll.WorkerReportsProgress = true;
            bgDecryptage.WorkerReportsProgress = true; bgDecryptAll.WorkerReportsProgress = true;
            btnCryptage.Enabled = false;
            btnDecryptage.Enabled = false;
            liste=new List<string>();
            RefreshBouton();
            /////////////////////////////////////////////////////////////////////
           
           // MessageBox.Show(InputFileAll);
        }

        //CRYPTAGE SOLO
        private void bgCryptage_DoWork(object sender, DoWorkEventArgs e)
        {
            try{
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                // FileInfo fi = new FileInfo(InputFile);
                String cryptFile =InputFile+".zrc";
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                FileStream fsln = new FileStream(InputFile, FileMode.Open);
                int data;
                int i = 0;
                long max = fsln.Length;
                int progress = 0;
                byte[] buffer = new byte[65536];
                while ((data = fsln.Read(buffer, 0, buffer.Length)) != 0) {
                    i += data;
                    cs.Write(buffer, 0, data);
                    progress = (int)((i / (float)max) * 100);
                    bgCryptage.ReportProgress(progress);
               }
                Console.WriteLine(fsln.Length);
                fsln.Close();
                cs.Close();
                fsCrypt.Close();
               
            }
            catch(Exception ex) {
                erreur = true;
                Console.WriteLine("Erreur cryptage");
                Console.WriteLine(ex.Message);
                MessageBox.Show("Fichier corrompu ou endommagé", "Erreur Cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgCryptage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Abs(e.ProgressPercentage);
            Console.WriteLine(e.ProgressPercentage);
        }

        private void bgCryptage_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!erreur) {
                progressBar1.Value = 100;
                try
                {
                    File.Delete(InputFile);
                }
                catch { }
                MessageBox.Show("Cryptage reussi", "Cryptage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button6.Enabled = true;
                btnCryptage.Enabled = false;
                btnDecryptage.Enabled = false;
                textBox2.Text = InputFile + ".zrc";
                InputFile = "";
                textBox1.Text = InputFile;
                progressBar1.Value = 0;
            }
            
        }

        //DECRYPTAGE SOLO
        private void bgDecryptage_DoWork(object sender, DoWorkEventArgs e)
        {
           try
             {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                FileStream fsCrypt = new FileStream(InputFile, FileMode.Open);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
                String destination = InputFile.Substring(0,InputFile.Length-4);
                FileStream fsOut = new FileStream(@""+destination, FileMode.Create);
                int data;
                int i = 0;
                long max = fsCrypt.Length;
                int progress = 0;
                byte[] buffer = new byte[65536];
                Console.WriteLine(max);
                while ((data = cs.Read(buffer, 0, buffer.Length)) != 0)
                {
                    i += data;
                    fsOut.Write(buffer,0,data);
                    progress = (int)((i / (float)max) * 100);
                    bgDecryptage.ReportProgress(progress);
                }

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
                
           }
            catch (Exception ex)
            {
                erreur = true;
                Console.WriteLine("Erreur décryptage");
                Console.WriteLine(ex.Message);
                MessageBox.Show("Fichier corrompu ou endommagé","Erreur décryptage",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bgDecryptage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Abs(e.ProgressPercentage);
        }

        private void bgDecryptage_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!erreur) {
                progressBar1.Value = 100;
                try
                {
                    File.Delete(InputFile);
                }
                catch { }

                MessageBox.Show("Décryptage reussi", "Décryptage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button6.Enabled = true;
                btnCryptage.Enabled = false;
                btnDecryptage.Enabled = false;
                textBox2.Text = InputFile.Substring(0, InputFile.Length - 4);
                InputFile = "";
                textBox1.Text = InputFile;
                progressBar1.Value = 0;
            }
            
            
        }

        private void btnCryptage_Click(object sender, EventArgs e)
        {
            erreur = false;
            bgCryptage.RunWorkerAsync();
            button6.Enabled = false;
            btnCryptage.Enabled = false;
            btnDecryptage.Enabled = false;
            textBox2.Text = "";
        }

        private void btnDecryptage_Click(object sender, EventArgs e)
        {
            erreur = false;
            bgDecryptage.RunWorkerAsync();
            button6.Enabled = false;
            btnCryptage.Enabled = false;
            btnDecryptage.Enabled = false;
            textBox2.Text = "";
        }
        //////////////////////////////////////////////////////////////
        //CRYPTAGE ALL
        private void bgCryptAll_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int i = 0;
                int progress = 0;
                long max = 0;
                int j = liste.Count; 
                foreach(String file in liste)
                {
                     UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);
                    FileInfo fi = new FileInfo(file);
                    String cryptFile = OutputDir + "\\"+fi.Name+".zrc";
                    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                    RijndaelManaged RMCrypto = new RijndaelManaged();
                    CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                    FileStream fsln = new FileStream(file, FileMode.Open);
                    int data;
                    
                     max += fsln.Length;
                    
                    byte[] buffer = new byte[65536];
                    while ((data = fsln.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        i += data;
                        cs.Write(buffer, 0, data);
                        progress = (int)((i / (float)max) * 100/j);
                        bgCryptAll.ReportProgress(progress);
                    }
                    Console.WriteLine(fsln.Length);
                    fsln.Close();
                    cs.Close();
                    fsCrypt.Close();
                    File.Delete(file);
                    j--;
                 }

           }
            catch (Exception ex)
            {
                erreur = true;
                Console.WriteLine("Erreur cryptage");
                Console.WriteLine(ex.Message);
                MessageBox.Show("Fichier corrompu ou endommagé", "Erreur Cryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgCryptAll_Progress(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = Math.Abs(e.ProgressPercentage);
        }

        private void bgCryptAll_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar2.Value = 100;
            MessageBox.Show("Cryptage reussi", "Cryptage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InputDir = "";
            OutputDir = "";
            liste.Clear();
            progressBar2.Value = 0;
            btnImage.Enabled = true;
            btnMusique.Enabled = true;
            btnVideo.Enabled = true;
            btnDocument.Enabled = true;
            btnLogiciel.Enabled = true;
            RefreshBouton();
        }
        //DECRYPTAGE ALL
        private void bgDecryptAll_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int i = 0;
                int progress = 0;
                long max = 0;
                int j = liste.Count; 
                foreach (String file in liste)
                {

                    UnicodeEncoding UE = new UnicodeEncoding();
                    byte[] key = UE.GetBytes(password);
                    FileStream fsCrypt = new FileStream(file, FileMode.Open);
                    RijndaelManaged RMCrypto = new RijndaelManaged();
                    CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
                    FileInfo fi = new FileInfo(file);
                    String fileSortie = fi.Name.Substring(0, fi.Name.Length - 4);
                    FileStream fsOut = new FileStream(@"" + OutputDir+"\\"+fileSortie, FileMode.Create);
                    int data;
                     max += fsCrypt.Length;
                    byte[] buffer = new byte[65536];
                    Console.WriteLine(max);
                    while ((data = cs.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        i += data;
                        fsOut.Write(buffer, 0, data);
                        progress = (int)((i / (float)max) * 100/j);
                        bgDecryptAll.ReportProgress(progress);
                    }

                    fsOut.Close();
                    cs.Close();
                    fsCrypt.Close();
                    File.Delete(file);
                    j--;
                }
               
            }
            catch (Exception ex)
            {
                erreur = true;
                Console.WriteLine("Erreur décryptage");
                Console.WriteLine(ex.Message);
                MessageBox.Show("Fichier corrompu ou endommagé", "Erreur décryptage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgDecryptAll_Progress(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = Math.Abs(e.ProgressPercentage);
        }

        private void bgDecryptAll_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar2.Value = 100;
            MessageBox.Show("Décryptage reussi", "Décryptage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InputDir = "";
            OutputDir = "";
            liste.Clear();
            progressBar2.Value = 0;
            EnableButton();
            RefreshBouton();
        }
        //BOUTON Cryptage et decryptage
        private void btnImage_Click(object sender, EventArgs e)
        {
            if (boolImage)
            {
                Console.WriteLine("22222222222");
                InputDir=CryptDir+"\\Images";
                OutputDir = DecryptDir + "\\Images";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgDecryptAll.RunWorkerAsync();
                DisableButton();
            }
            else {
                Console.WriteLine("1111111111111");
                InputDir = DecryptDir+ "\\Images";
                OutputDir = CryptDir + "\\Images";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgCryptAll.RunWorkerAsync();
                DisableButton();
            }
          
           
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            if (boolVideo)
            {
                InputDir = CryptDir + "\\Videos";
                OutputDir = DecryptDir + "\\Videos";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgDecryptAll.RunWorkerAsync();
                DisableButton();
            }
            else
            {
                InputDir = DecryptDir + "\\Videos";
                OutputDir = CryptDir + "\\Videos";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgCryptAll.RunWorkerAsync();
                DisableButton();
            }
        }

        private void btnMusique_Click(object sender, EventArgs e)
        {
            if (boolMusique)
            {
                InputDir = CryptDir + "\\Musiques";
                OutputDir = DecryptDir + "\\Musiques";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgDecryptAll.RunWorkerAsync();
                DisableButton();
            }
            else
            {
                InputDir = DecryptDir + "\\Musiques";
                OutputDir = CryptDir + "\\Musiques";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgCryptAll.RunWorkerAsync();
                DisableButton();
            }
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            if (boolDocument)
            {
                InputDir = CryptDir + "\\Documents";
                OutputDir = DecryptDir + "\\Documents";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgDecryptAll.RunWorkerAsync();
                DisableButton();
            }
            else
            {
                InputDir = DecryptDir + "\\Documents";
                OutputDir = CryptDir + "\\Documents";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgCryptAll.RunWorkerAsync();
                DisableButton();
            }
        }

        private void btnLogiciel_Click(object sender, EventArgs e)
        {
            if (boolVideo)
            {
                InputDir = CryptDir + "\\Logiciels";
                OutputDir = DecryptDir + "\\Logiciels";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgDecryptAll.RunWorkerAsync();
                DisableButton();
            }
            else
            {
                InputDir = DecryptDir + "\\Logiciels";
                OutputDir = CryptDir + "\\Logiciels";
                foreach (String item in Directory.GetFiles(InputDir))
                {
                    liste.Add(item);
                }
                bgCryptAll.RunWorkerAsync();
                DisableButton();
            }
        }
        private void DisableButton(){
            btnImage.Enabled = false;
            btnMusique.Enabled = false;
            btnVideo.Enabled = false;
            btnDocument.Enabled = false;
            btnLogiciel.Enabled = false;
            btnRefresh.Enabled = false;
        }
        private void EnableButton() {

            btnImage.Enabled = true;
            btnMusique.Enabled = true;
            btnVideo.Enabled = true;
            btnDocument.Enabled = true;
            btnLogiciel.Enabled = true;
            btnRefresh.Enabled = true;
        }
        private void RefreshBouton() {
            if (Directory.GetFiles(DecryptDir + "\\Images").Length == 0 && Directory.GetFiles(CryptDir + "\\Images").Length == 0)
            {
                btnImage.Enabled = false;
            }
            else
            {
                btnImage.Enabled = true;
            }
            if (Directory.GetFiles(DecryptDir + "\\Videos").Length == 0 && Directory.GetFiles(CryptDir + "\\Videos").Length == 0)
            {
                btnVideo.Enabled = false;
            }
            else
            {
                btnVideo.Enabled = true;
            }
            if (Directory.GetFiles(DecryptDir + "\\Musiques").Length == 0 && Directory.GetFiles(CryptDir + "\\Musiques").Length == 0)
            {
                btnMusique.Enabled = false;
            }
            else
            {
                btnMusique.Enabled = true;
            }
            if (Directory.GetFiles(DecryptDir + "\\Documents").Length == 0 && Directory.GetFiles(CryptDir + "\\Documents").Length == 0)
            {
                btnDocument.Enabled = false;
            }
            else
            {
                btnDocument.Enabled = true;
            }
            if (Directory.GetFiles(DecryptDir + "\\Logiciels").Length == 0 && Directory.GetFiles(CryptDir + "\\Logiciels").Length == 0)
            {
                btnLogiciel.Enabled = false;
            }
            else
            {
                btnLogiciel.Enabled = true;
            }
            ///////////////////////////////////////////////////////////
            if (Directory.GetFiles(CryptDir + "\\Images").Length > 0)
            {
                btnImage.Text = "Décrypter les images";
                boolImage = true;
            }
            else
            {
                btnImage.Text = "Crypter les images";
                boolImage = false;
            }
            if (Directory.GetFiles(CryptDir + "\\Musiques").Length > 0)
            {
                btnMusique.Text = "Décrypter les musiques";
                boolMusique = true;
            }
            else
            {
                btnMusique.Text = "Crypter les musiques";
                boolMusique = false;
            }
            if (Directory.GetFiles(CryptDir + "\\Videos").Length > 0)
            {
                btnVideo.Text = "Décrypter les vidéos";
                boolVideo = true;
            }
            else
            {
                btnVideo.Text = "Crypter les vidéos";
                boolVideo = false;
            }
            if (Directory.GetFiles(CryptDir + "\\Documents").Length > 0)
            {
                btnDocument.Text = "Décrypter les documents";
                boolDocument = true;
            }
            else
            {
                btnDocument.Text = "Crypter les documents";
                boolDocument = false;
            }
            if (Directory.GetFiles(CryptDir + "\\Logiciels").Length > 0)
            {
                btnLogiciel.Text = "Décrypter les logiciels";
                boolLogiciel = true;
            }
            else
            {
                btnLogiciel.Text = "Crypter les logiciels";
                boolLogiciel = false;
            }
        
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBouton();
            Refresh();

        }

       
    }
}
