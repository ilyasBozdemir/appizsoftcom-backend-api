using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Dtos.Configuration
{
    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<EnumProperty> Properties { get; set; } = new();

    }
    public class EnumProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
