using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Configuration
{
    public class BaseUrl
    {
        public Url DevelopmentUrl { get; set; }
        public Url ProductionUrl { get; set; }
        public Url StagingUrl { get; set; }

    }

    public class Url
    {
        public string HttpUrl { get; set; }
        public string HttpsUrl { get; set; }
    }


}
