namespace SecureFileEncryptor
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbFileEncryption = new GroupBox();
            btnStartEncryption = new Button();
            btnSetPasswordForEncrypt = new Button();
            btnSelectMainFile = new Button();
            gbFileDecryption = new GroupBox();
            btnStartDecryption = new Button();
            btnSetPasswordForDecrypt = new Button();
            btnSelectEncryptedFile = new Button();
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            forEncryptionWebsiteToolStripMenuItem = new ToolStripMenuItem();
            gbFileEncryption.SuspendLayout();
            gbFileDecryption.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gbFileEncryption
            // 
            gbFileEncryption.Controls.Add(btnStartEncryption);
            gbFileEncryption.Controls.Add(btnSetPasswordForEncrypt);
            gbFileEncryption.Controls.Add(btnSelectMainFile);
            gbFileEncryption.Location = new Point(12, 33);
            gbFileEncryption.Name = "gbFileEncryption";
            gbFileEncryption.Size = new Size(504, 157);
            gbFileEncryption.TabIndex = 0;
            gbFileEncryption.TabStop = false;
            gbFileEncryption.Text = "File Encryption";
            // 
            // btnStartEncryption
            // 
            btnStartEncryption.Enabled = false;
            btnStartEncryption.Font = new Font("Segoe UI", 15.75F);
            btnStartEncryption.ForeColor = Color.FromArgb(64, 64, 64);
            btnStartEncryption.Location = new Point(336, 22);
            btnStartEncryption.Name = "btnStartEncryption";
            btnStartEncryption.Size = new Size(159, 115);
            btnStartEncryption.TabIndex = 2;
            btnStartEncryption.Text = "Start Encryption";
            btnStartEncryption.UseVisualStyleBackColor = true;
            btnStartEncryption.Click += btnStartEncryption_Click;
            // 
            // btnSetPasswordForEncrypt
            // 
            btnSetPasswordForEncrypt.Enabled = false;
            btnSetPasswordForEncrypt.Font = new Font("Segoe UI", 15.75F);
            btnSetPasswordForEncrypt.ForeColor = Color.FromArgb(64, 64, 64);
            btnSetPasswordForEncrypt.Location = new Point(171, 22);
            btnSetPasswordForEncrypt.Name = "btnSetPasswordForEncrypt";
            btnSetPasswordForEncrypt.Size = new Size(159, 115);
            btnSetPasswordForEncrypt.TabIndex = 1;
            btnSetPasswordForEncrypt.Text = "Set Password For Encryption";
            btnSetPasswordForEncrypt.UseVisualStyleBackColor = true;
            btnSetPasswordForEncrypt.Click += btnSetPasswordForEncrypt_Click;
            // 
            // btnSelectMainFile
            // 
            btnSelectMainFile.Font = new Font("Segoe UI", 15.75F);
            btnSelectMainFile.ForeColor = Color.FromArgb(64, 64, 64);
            btnSelectMainFile.Location = new Point(6, 22);
            btnSelectMainFile.Name = "btnSelectMainFile";
            btnSelectMainFile.Size = new Size(159, 115);
            btnSelectMainFile.TabIndex = 0;
            btnSelectMainFile.Text = "Select Main File";
            btnSelectMainFile.UseVisualStyleBackColor = true;
            btnSelectMainFile.Click += btnSelectMainFile_Click;
            // 
            // gbFileDecryption
            // 
            gbFileDecryption.Controls.Add(btnStartDecryption);
            gbFileDecryption.Controls.Add(btnSetPasswordForDecrypt);
            gbFileDecryption.Controls.Add(btnSelectEncryptedFile);
            gbFileDecryption.Location = new Point(12, 196);
            gbFileDecryption.Name = "gbFileDecryption";
            gbFileDecryption.Size = new Size(504, 157);
            gbFileDecryption.TabIndex = 3;
            gbFileDecryption.TabStop = false;
            gbFileDecryption.Text = "File Decryption";
            // 
            // btnStartDecryption
            // 
            btnStartDecryption.Enabled = false;
            btnStartDecryption.Font = new Font("Segoe UI", 15.75F);
            btnStartDecryption.ForeColor = Color.FromArgb(64, 64, 64);
            btnStartDecryption.Location = new Point(336, 22);
            btnStartDecryption.Name = "btnStartDecryption";
            btnStartDecryption.Size = new Size(159, 115);
            btnStartDecryption.TabIndex = 2;
            btnStartDecryption.Text = "Start Decryption";
            btnStartDecryption.UseVisualStyleBackColor = true;
            btnStartDecryption.Click += btnStartDecryption_Click;
            // 
            // btnSetPasswordForDecrypt
            // 
            btnSetPasswordForDecrypt.Enabled = false;
            btnSetPasswordForDecrypt.Font = new Font("Segoe UI", 15.75F);
            btnSetPasswordForDecrypt.ForeColor = Color.FromArgb(64, 64, 64);
            btnSetPasswordForDecrypt.Location = new Point(171, 22);
            btnSetPasswordForDecrypt.Name = "btnSetPasswordForDecrypt";
            btnSetPasswordForDecrypt.Size = new Size(159, 115);
            btnSetPasswordForDecrypt.TabIndex = 1;
            btnSetPasswordForDecrypt.Text = "Enter Password";
            btnSetPasswordForDecrypt.UseVisualStyleBackColor = true;
            btnSetPasswordForDecrypt.Click += btnSetPasswordForDecrypt_Click;
            // 
            // btnSelectEncryptedFile
            // 
            btnSelectEncryptedFile.Font = new Font("Segoe UI", 15.75F);
            btnSelectEncryptedFile.ForeColor = Color.FromArgb(64, 64, 64);
            btnSelectEncryptedFile.Location = new Point(6, 22);
            btnSelectEncryptedFile.Name = "btnSelectEncryptedFile";
            btnSelectEncryptedFile.Size = new Size(159, 115);
            btnSelectEncryptedFile.TabIndex = 0;
            btnSelectEncryptedFile.Text = "Select Encrypted File";
            btnSelectEncryptedFile.UseVisualStyleBackColor = true;
            btnSelectEncryptedFile.Click += btnSelectEncryptedFile_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(526, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { forEncryptionWebsiteToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // forEncryptionWebsiteToolStripMenuItem
            // 
            forEncryptionWebsiteToolStripMenuItem.Name = "forEncryptionWebsiteToolStripMenuItem";
            forEncryptionWebsiteToolStripMenuItem.Size = new Size(193, 22);
            forEncryptionWebsiteToolStripMenuItem.Text = "ForEncryption Website";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 365);
            Controls.Add(gbFileDecryption);
            Controls.Add(gbFileEncryption);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Secure File Encryptor";
            gbFileEncryption.ResumeLayout(false);
            gbFileDecryption.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbFileEncryption;
        private Button btnSelectMainFile;
        private Button btnStartEncryption;
        private Button btnSetPasswordForEncrypt;
        private GroupBox gbFileDecryption;
        private Button btnStartDecryption;
        private Button btnSetPasswordForDecrypt;
        private Button btnSelectEncryptedFile;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem forEncryptionWebsiteToolStripMenuItem;
    }
}
