namespace Desktop_zarao
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDecryptage = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCryptage = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnMusique = new System.Windows.Forms.Button();
            this.btnDocument = new System.Windows.Forms.Button();
            this.btnLogiciel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bgCryptage = new System.ComponentModel.BackgroundWorker();
            this.bgDecryptage = new System.ComponentModel.BackgroundWorker();
            this.bgCryptAll = new System.ComponentModel.BackgroundWorker();
            this.bgDecryptAll = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnDecryptage);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.btnCryptage);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autres cryptage";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(75, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(560, 13);
            this.textBox2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Destination:";
            // 
            // btnDecryptage
            // 
            this.btnDecryptage.Location = new System.Drawing.Point(563, 21);
            this.btnDecryptage.Name = "btnDecryptage";
            this.btnDecryptage.Size = new System.Drawing.Size(72, 23);
            this.btnDecryptage.TabIndex = 4;
            this.btnDecryptage.Text = "Decrypter";
            this.btnDecryptage.UseVisualStyleBackColor = true;
            this.btnDecryptage.Click += new System.EventHandler(this.btnDecryptage_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 50);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(629, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // btnCryptage
            // 
            this.btnCryptage.Location = new System.Drawing.Point(485, 21);
            this.btnCryptage.Name = "btnCryptage";
            this.btnCryptage.Size = new System.Drawing.Size(72, 23);
            this.btnCryptage.TabIndex = 2;
            this.btnCryptage.Text = "Crypter";
            this.btnCryptage.UseVisualStyleBackColor = true;
            this.btnCryptage.Click += new System.EventHandler(this.btnCryptage_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(357, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Importer fichier";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(6, 19);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(121, 23);
            this.btnImage.TabIndex = 0;
            this.btnImage.Text = "Crypter les Images";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(133, 19);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(121, 23);
            this.btnVideo.TabIndex = 1;
            this.btnVideo.Text = "Crypter les vidéos";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnMusique
            // 
            this.btnMusique.Location = new System.Drawing.Point(260, 19);
            this.btnMusique.Name = "btnMusique";
            this.btnMusique.Size = new System.Drawing.Size(121, 23);
            this.btnMusique.TabIndex = 2;
            this.btnMusique.Text = "Crypter les musiques";
            this.btnMusique.UseVisualStyleBackColor = true;
            this.btnMusique.Click += new System.EventHandler(this.btnMusique_Click);
            // 
            // btnDocument
            // 
            this.btnDocument.Location = new System.Drawing.Point(387, 19);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(121, 23);
            this.btnDocument.TabIndex = 3;
            this.btnDocument.Text = "Crypter les documents";
            this.btnDocument.UseVisualStyleBackColor = true;
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
            // 
            // btnLogiciel
            // 
            this.btnLogiciel.Location = new System.Drawing.Point(514, 19);
            this.btnLogiciel.Name = "btnLogiciel";
            this.btnLogiciel.Size = new System.Drawing.Size(121, 23);
            this.btnLogiciel.TabIndex = 4;
            this.btnLogiciel.Text = "Crypter les logiciels";
            this.btnLogiciel.UseVisualStyleBackColor = true;
            this.btnLogiciel.Click += new System.EventHandler(this.btnLogiciel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.btnLogiciel);
            this.groupBox1.Controls.Add(this.btnDocument);
            this.groupBox1.Controls.Add(this.btnMusique);
            this.groupBox1.Controls.Add(this.btnVideo);
            this.groupBox1.Controls.Add(this.btnImage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dossier zarao web";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(529, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Actualiser boutons";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(6, 57);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(517, 23);
            this.progressBar2.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bgCryptage
            // 
            this.bgCryptage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCryptage_DoWork);
            this.bgCryptage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgCryptage_ProgressChanged);
            this.bgCryptage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCryptage_Completed);
            // 
            // bgDecryptage
            // 
            this.bgDecryptage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDecryptage_DoWork);
            this.bgDecryptage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgDecryptage_ProgressChanged);
            this.bgDecryptage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDecryptage_Completed);
            // 
            // bgCryptAll
            // 
            this.bgCryptAll.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCryptAll_DoWork);
            this.bgCryptAll.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgCryptAll_Progress);
            this.bgCryptAll.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCryptAll_Completed);
            // 
            // bgDecryptAll
            // 
            this.bgDecryptAll.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDecryptAll_DoWork);
            this.bgDecryptAll.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgDecryptAll_Progress);
            this.bgDecryptAll.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDecryptAll_Completed);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(670, 239);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cryptage Zara-ao";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecryptage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCryptage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnMusique;
        private System.Windows.Forms.Button btnDocument;
        private System.Windows.Forms.Button btnLogiciel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker bgCryptage;
        private System.ComponentModel.BackgroundWorker bgDecryptage;
        private System.Windows.Forms.TextBox textBox2;
        private System.ComponentModel.BackgroundWorker bgCryptAll;
        private System.ComponentModel.BackgroundWorker bgDecryptAll;
        private System.Windows.Forms.Button btnRefresh;
    }
}