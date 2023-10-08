using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Configuration
{
    public class ApiConfiguration
    {
        public BaseUrl BaseUrl { get; set; }
        public string Version { get; set; }
        public List<Header> Headers { get; set; } = new();
        public List<Controller> Controllers { get; set; }
    }
}
