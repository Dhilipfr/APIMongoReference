using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry.Core.Models.Application
{
    public class AppSettings
    {
        public string[] AllowMyOrigins { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
