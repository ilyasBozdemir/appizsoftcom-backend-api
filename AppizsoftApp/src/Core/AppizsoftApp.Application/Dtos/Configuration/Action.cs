using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Configuration
{
    public class Action
    {
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Route { get; set; }
        public string ContentType { get; set; }
        public List<Parameter> Parameters { get; set; } = new();

    }
}
