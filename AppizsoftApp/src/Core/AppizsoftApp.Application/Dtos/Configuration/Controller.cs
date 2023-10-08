using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Configuration
{
    public class Controller
    {
        public string Name { get; set; }
        public string BasePath { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
