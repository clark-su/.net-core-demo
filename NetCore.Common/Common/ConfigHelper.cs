using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCore.Common.Common
{
    public class ConfigHelper
    {
        private static ConfigHelper config = null;

        public static ConfigHelper Config
        {
            get
            {
                if (config == null)
                {
                    config = new ConfigHelper();
                }
                return config;
            }
        }

        public IConfiguration Configuration { get; }

        public ConfigHelper()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        private string con;

        public string Con
        {
            get
            {
                if (string.IsNullOrEmpty(con))
                    con = Configuration.GetConnectionString("DefaultConnection");
                return con;
            }
        }
    }
}
