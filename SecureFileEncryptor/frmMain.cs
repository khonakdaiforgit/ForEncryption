namespace SecureFileEncryptor
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private string selectedFilePath;
        public static string Password;


        private void btnSelectMainFile_Click(object sender, EventArgs e)
        {
            selectedFilePath = null;
            // Create an instance of OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Optional: Set properties for the dialog
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt"; // Example filter
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Show the dialog and check if the user clicked OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the selected file path in a variable
                    selectedFilePath = openFileDialog.FileName;
                    btnSetPasswordForEncrypt.Enabled = true;
                    btnSetPasswordForEncrypt.Focus();
                }
                else
                {
                    btnSetPasswordForEncrypt.Enabled = false;
                    btnSelectMainFile.Focus();
                }
            }
        }

        private void btnSetPasswordForEncrypt_Click(object sender, EventArgs e)
        {
            Password = null;
            frmSetPassword frmSetPassword = new frmSetPassword();
            frmSetPassword.ShowDialog();
            if (Password != null)
            {
                btnStartEncryption.Enabled = true;
                btnStartEncryption.Focus();
            }
        }

        private void btnStartEncryption_Click(object sender, EventArgs e)
        {
            FileEncryptor.EncryptFile(selectedFilePath, Password);

        }

        private void btnSelectEncryptedFile_Click(object sender, EventArgs e)
        {
            selectedFilePath = null;
            // Create an instance of OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Optional: Set properties for the dialog
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt"; // Example filter
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Show the dialog and check if the user clicked OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the selected file path in a variable
                    selectedFilePath = openFileDialog.FileName;
                    btnSetPasswordForDecrypt.Enabled = true;
                    btnSetPasswordForDecrypt.Focus();
                }
                else
                {
                    btnSetPasswordForDecrypt.Enabled = false;
                    btnSetPasswordForDecrypt.Focus();
                }
            }
        }

        private void btnSetPasswordForDecrypt_Click(object sender, EventArgs e)
        {
            Password = null;
            frmSetPassword frmSetPassword = new frmSetPassword();
            frmSetPassword.ShowDialog();
            if (Password != null)
            {
                btnStartDecryption.Enabled = true;
                btnStartDecryption.Focus();
            }
        }

        private void btnStartDecryption_Click(object sender, EventArgs e)
        {
            FileEncryptor.DecryptFile(selectedFilePath, Password);
        }
    }
}
