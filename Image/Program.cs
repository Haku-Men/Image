using System.ServiceProcess;

namespace Image
{
    internal static class Program
    {
        public static System.Diagnostics.Process Pro = System.Diagnostics.Process.GetCurrentProcess();
        public static string ExePath = Pro.MainModule.FileName;
        public static string BasePath = new FileInfo(ExePath).DirectoryName + Path.DirectorySeparatorChar;
        public static string DbPath = BasePath + "image" + Path.DirectorySeparatorChar;
        public static string TempPath = BasePath + "temp" + Path.DirectorySeparatorChar;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arge)
        {
            if (arge.Length > 0)
            {
                string argeline = string.Join(" ", arge);
                if (argeline == "service")
                {
                    ServiceBase.Run(new ServiceBase[]
                    {
                        new Service()
                    });
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}