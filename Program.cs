using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DoraTourist.API
{
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         CreateWebHostBuilder(args).Build().Run();
    //     }

    //     public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //         WebHost.CreateDefaultBuilder(args)
    //             .UseStartup<Startup>();
    // }
    
     public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("https://*:5001") // Using * to bind to all network interfaces
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
