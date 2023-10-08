using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Configuration
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Property> Properties { get; set; } = new();
 
        public string Description { get; set; }
    }
}
