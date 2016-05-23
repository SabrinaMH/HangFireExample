using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Microsoft.Owin.Hosting;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("dbConnection");
            LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());
            using (WebApp.Start<Startup>("http://localhost:9000"))
            {
                using (new BackgroundJobServer())
                {
                    Console.WriteLine("HangFire server started");
                    Console.ReadKey();
                }
            }
        }
    }
}
