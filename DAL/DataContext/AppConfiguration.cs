using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            configBuilder.AddJsonFile(path, false);

            var root = configBuilder.Build();

            var appSettings = root.GetSection("ConnectionStrings:myCon");

            sqlConnectionString = appSettings.Value;
        }

        public string sqlConnectionString { get; private set; }
    }
}
