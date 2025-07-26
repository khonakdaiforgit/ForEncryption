namespace SecureFileEncryptor
{
    internal static class Program
    {
        public static string WebsiteUrl { get; set; } = "http://forencryption.runasp.net/";
        public static int FreeUsingCount { get; set; } = 20;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flowControl = CheckLimitation();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }

        public static bool CheckLimitation()
        {
            int usageCount = Properties.Settings.Default.UsageCount;
            if (usageCount >= FreeUsingCount)
            {
                MessageBox.Show($"The free usage limit of this app has been reached at {FreeUsingCount} times.", "Free usage limit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}