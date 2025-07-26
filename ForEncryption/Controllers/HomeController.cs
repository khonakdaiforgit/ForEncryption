using ForEncryption.Models;
using ForEncryption.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        //https://localhost:7114/?pass=1146
        public IActionResult Index(int pass)
        {
            //if (pass == 1146)
                return View();
            //else return Content("Access dined !");
        }

        public IActionResult Donation()
        {
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

        [HttpGet]
        public IActionResult Encrypt()
        {
            return View(new EncryptionVIewModel());
        }

        // POST: Handle encryption
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Encrypt(EncryptionVIewModel model)
        {
            if (ModelState.IsValid &&
                !string.IsNullOrEmpty(model.PlainText) && !string.IsNullOrEmpty(model.EncryptionKey))
            {
                try
                {
                    model.EncryptedText = _dataEncryption.Encrypt(model.PlainText, model.EncryptionKey);

                }
                catch
                {
                    ModelState.AddModelError("", "Encryption failed. Please check your key.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Decrypt()
        {
            return View(new DecryptionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Decrypt([FromForm] DecryptionViewModel model)
        {
            if (ModelState.IsValid &&
                !string.IsNullOrEmpty(model.EncryptedText) && !string.IsNullOrEmpty(model.EncryptionKey))
            {
                try
                {
                    model.DecryptedText = _dataEncryption.Decrypt(model.EncryptedText, model.EncryptionKey);
                }
                catch
                {
                    ModelState.AddModelError("", "Decryption failed. Please check your key or encrypted text.");
                }
            }
            return View(model);
        }
        public IActionResult Application()
        {
            return View();
        }
    }
}
