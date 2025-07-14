using System.Security.Cryptography;
using System.Text;

namespace ForEncryption.Service
{
    public class DataEncryption
    {
        public string Encrypt(string plainText, string password)
        {
            byte[] _key;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("St123al4"), 100000, HashAlgorithmName.SHA256))
            {
                _key = deriveBytes.GetBytes(32); // کلید 256 بیتی برای AES
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.Mode = CipherMode.CBC; // حالت CBC
                aes.Padding = PaddingMode.PKCS7; // پدینگ PKCS7
                aes.GenerateIV(); // تولید IV تصادفی

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    // ذخیره IV در ابتدای خروجی
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText, string password)
        {
            byte[] _key;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("St123al4"), 100000, HashAlgorithmName.SHA256))
            {
                _key = deriveBytes.GetBytes(32); // کلید 256 بیتی برای AES
            }

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.Mode = CipherMode.CBC; // حالت CBC
                aes.Padding = PaddingMode.PKCS7; // پدینگ PKCS7

                // استخراج IV از 16 بایت اول
                byte[] iv = new byte[16];
                Array.Copy(cipherBytes, 0, iv, 0, 16);
                aes.IV = iv;

                // استخراج ciphertext
                byte[] cipherOnly = new byte[cipherBytes.Length - 16];
                Array.Copy(cipherBytes, 16, cipherOnly, 0, cipherOnly.Length);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(cipherOnly))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
