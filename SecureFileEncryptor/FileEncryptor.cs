using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureFileEncryptor
{
    public class FileEncryptor
    {
        private const string Salt = "St123al4"; // Match MVC app
        private const int Iterations = 100000; // Match MVC app
        public static void EncryptFile(string inputFilePath, string password)
        {
            try
            {
                // Validate inputs
                if (!File.Exists(inputFilePath))
                    throw new FileNotFoundException("Input file does not exist.", inputFilePath);
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentException("Password cannot be null or empty.", nameof(password));

                // Open FolderBrowserDialog to get output directory
                string outputDir;
                using (var dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Select the output directory for the encrypted file";
                    dialog.ShowNewFolderButton = true;
                    if (dialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        MessageBox.Show("No directory selected. Operation cancelled.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    outputDir = dialog.SelectedPath;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(outputDir);

                // Generate output filename with .enc extension
                string outputFilePath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputFilePath) + ".enc");

                // Read the input file
                byte[] fileData = File.ReadAllBytes(inputFilePath);
                string originalFileName = Path.GetFileName(inputFilePath);

                // Prepare data to encrypt: filename length (4 bytes) + filename + file data
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(originalFileName);
                byte[] fileNameLength = BitConverter.GetBytes(fileNameBytes.Length);
                byte[] dataToEncrypt = new byte[fileNameLength.Length + fileNameBytes.Length + fileData.Length];
                Buffer.BlockCopy(fileNameLength, 0, dataToEncrypt, 0, fileNameLength.Length);
                Buffer.BlockCopy(fileNameBytes, 0, dataToEncrypt, fileNameLength.Length, fileNameBytes.Length);
                Buffer.BlockCopy(fileData, 0, dataToEncrypt, fileNameLength.Length + fileNameBytes.Length, fileData.Length);

                // Generate key from password using Rfc2898DeriveBytes
                byte[] key;
                using (var deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(Salt), Iterations, HashAlgorithmName.SHA256))
                {
                    key = deriveBytes.GetBytes(32); // AES-256 key
                }

                // Encrypt the data
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.GenerateIV();

                    using (var outputFileStream = new FileStream(outputFilePath, FileMode.Create))
                    {
                        // Write IV to the output file
                        outputFileStream.Write(aes.IV, 0, aes.IV.Length);

                        // Encrypt and write the data
                        using (var cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                    }
                }

                MessageBox.Show($"File encrypted successfully and saved as: {outputFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Encryption failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DecryptFile(string encryptedFilePath, string password)
        {
            try
            {
                // Validate inputs
                if (!File.Exists(encryptedFilePath))
                    throw new FileNotFoundException("Encrypted file does not exist.", encryptedFilePath);
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentException("Password cannot be null or empty.", nameof(password));

                // Open FolderBrowserDialog to get output directory
                string outputDir;
                using (var dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "Select the output directory for the decrypted file";
                    dialog.ShowNewFolderButton = true;
                    if (dialog.ShowDialog() != DialogResult.OK || string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        MessageBox.Show("No directory selected. Operation cancelled.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    outputDir = dialog.SelectedPath;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(outputDir);

                // Read the encrypted file
                byte[] encryptedData = File.ReadAllBytes(encryptedFilePath);
                if (encryptedData.Length < 16)
                    throw new ArgumentException("Encrypted file is too short to contain a valid IV.");

                // Generate key from password using Rfc2898DeriveBytes
                byte[] key;
                using (var deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(Salt), Iterations, HashAlgorithmName.SHA256))
                {
                    key = deriveBytes.GetBytes(32); // AES-256 key
                }

                // Decrypt the data
                byte[] decryptedData;
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    // Extract IV from the first 16 bytes
                    byte[] iv = new byte[16];
                    Array.Copy(encryptedData, 0, iv, 0, 16);
                    aes.IV = iv;

                    // Extract ciphertext (skip IV)
                    byte[] cipherOnly = new byte[encryptedData.Length - 16];
                    Array.Copy(encryptedData, 16, cipherOnly, 0, cipherOnly.Length);

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(cipherOnly, 0, cipherOnly.Length);
                            cryptoStream.FlushFinalBlock();
                            decryptedData = memoryStream.ToArray();
                        }
                    }
                }

                // Extract original filename and file data
                if (decryptedData.Length < 4)
                    throw new ArgumentException("Decrypted data is too short to contain a valid filename length.");

                int fileNameLength = BitConverter.ToInt32(decryptedData, 0);
                if (fileNameLength < 0 || fileNameLength > decryptedData.Length - 4)
                    throw new ArgumentException("Invalid filename length in decrypted data.");

                string originalFileName = Encoding.UTF8.GetString(decryptedData, 4, fileNameLength);
                if (string.IsNullOrEmpty(originalFileName))
                    throw new ArgumentException("Invalid or empty filename in decrypted data.");

                byte[] fileData = new byte[decryptedData.Length - 4 - fileNameLength];
                Buffer.BlockCopy(decryptedData, 4 + fileNameLength, fileData, 0, fileData.Length);

                // Save the decrypted file
                string outputFilePath = Path.Combine(outputDir, originalFileName);
                File.WriteAllBytes(outputFilePath, fileData);

                MessageBox.Show($"File decrypted successfully and saved as: {outputFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show($"Decryption failed, possibly due to an incorrect password or corrupted file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decryption failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
