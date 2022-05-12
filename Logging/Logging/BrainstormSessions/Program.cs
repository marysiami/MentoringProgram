using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.EmailPickup;
using System;
using System.IO;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //https://github.com/gkinsman/Serilog.Sinks.EmailPickup
            var currentDir = Environment.CurrentDirectory;
            var logDir = Path.Combine(currentDir ,"SmtpPickupDirAppenderTest_PickupDir");

            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .WriteTo.EmailPickup(
                                fromEmail: "app@example.com",
                                toEmail: "support@example.com",
                                pickupDirectory: logDir,
                                subject: "LOGS from application",
                                fileExtension: ".email",
                                restrictedToMinimumLevel: LogEventLevel.Information)
                            .CreateLogger();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
