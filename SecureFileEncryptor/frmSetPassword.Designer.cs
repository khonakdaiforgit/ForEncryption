namespace SecureFileEncryptor
{
    partial class frmSetPassword
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
            txtPassword = new TextBox();
            btnSetPassword = new Button();
            btnShowPass = new Button();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(12, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(379, 35);
            txtPassword.TabIndex = 0;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnSetPassword
            // 
            btnSetPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSetPassword.Location = new Point(294, 53);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(155, 34);
            btnSetPassword.TabIndex = 1;
            btnSetPassword.Text = "Set Password";
            btnSetPassword.UseVisualStyleBackColor = true;
            btnSetPassword.Click += btnSetPassword_Click;
            // 
            // btnShowPass
            // 
            btnShowPass.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowPass.Location = new Point(397, 12);
            btnShowPass.Name = "btnShowPass";
            btnShowPass.Size = new Size(52, 34);
            btnShowPass.TabIndex = 2;
            btnShowPass.Text = "Show";
            btnShowPass.UseVisualStyleBackColor = true;
            btnShowPass.MouseDown += btnShowPass_MouseDown;
            btnShowPass.MouseUp += btnShowPass_MouseUp;
            // 
            // frmSetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 101);
            Controls.Add(btnShowPass);
            Controls.Add(btnSetPassword);
            Controls.Add(txtPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmSetPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Set Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Button btnSetPassword;
        private Button btnShowPass;
    }
}