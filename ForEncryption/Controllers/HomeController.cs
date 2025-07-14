using ForEncryption.Models;
using ForEncryption.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ForEncryption.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataEncryption _dataEncryption;
        public HomeController(
            ILogger<HomeController> logger,
            DataEncryption dataEncryption)
        {
            _logger = logger;
            _dataEncryption = dataEncryption;
        }

        public IActionResult Index()
        {
            //var xx=encryption.Encrypt("فردا باید بریم به مدار 576 برای تجدید قوا");
            //EncryptionTool.DataEncryption encryption = new EncryptionTool.DataEncryption("asd");
            //var xx = encryption.Encrypt("Simple IV for demo; in production, use a random IV");

            //var dexx = encryption.Decrypt(xx);
            //DecryptionViewModel encryptionModel = new DecryptionViewModel();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Encrypt()
        {
            return View(new EncryptionVIewModel());
        }

        // POST: Handle encryption
        [HttpPost]
        public IActionResult Encrypt(EncryptionVIewModel model)
        {
            if (!string.IsNullOrEmpty(model.PlainText) && !string.IsNullOrEmpty(model.EncryptionKey))
            {
                try
                {

                    // model.EncryptedText = EncryptText(model.PlainText, model.EncryptionKey);
                    model.EncryptedText = _dataEncryption.Encrypt(model.PlainText, model.EncryptionKey);

                }
                catch
                {
                    ModelState.AddModelError("", "Encryption failed. Please check your key.");
                }
            }
            return View(model);
        }

        public IActionResult Decrypt()
        {
            return View(new DecryptionViewModel());
        }

        // POST: Handle decryption
        [HttpPost]
        public IActionResult Decrypt(DecryptionViewModel model)
        {
            if (!string.IsNullOrEmpty(model.EncryptedText) && !string.IsNullOrEmpty(model.EncryptionKey))
            {
                try
                {
                    //model.DecryptedText = DecryptText(model.EncryptedText, model.EncryptionKey);
                    model.DecryptedText = _dataEncryption.Decrypt(model.EncryptedText, model.EncryptionKey);
                }
                catch
                {
                    ModelState.AddModelError("", "Decryption failed. Please check your key or encrypted text.");
                }
            }
            return View(model);
        }

        // Encrypts text using AES
        private string EncryptText(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                aes.IV = new byte[16]; // Zero IV for simplicity
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
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

        // Decrypts text using AES
        private string DecryptText(string encryptedText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
                aes.IV = new byte[16]; // Zero IV for simplicity
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
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
