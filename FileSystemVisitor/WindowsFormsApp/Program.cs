using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IFileSystemService, FileSystemService>();
            services.AddSingleton<IFileProvider, PhysicalFileProvider>();
            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureServices();
            Application.Run(new FileSystemForm());

        }
    }
}
