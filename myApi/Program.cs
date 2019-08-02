using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using barisApi.Controllers;
using myApi.Models;
using System.Net;

namespace myApi
{
    public class Program
    {

        public static void Main(string[] args)
        {




            var host = new WebHostBuilder()
             .UseUrls("http://192.168.1.2:5010", "http://192.168.1.2:5012")
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .UseStartup<Startup>()
             .Build();
            host.Run();


        }



    }
}
