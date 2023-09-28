using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Enums
{

    [Flags]
    public enum Roles
    {
        None = 0,
        SuperAdmin = 1,
        Admin = 2,
        User = 4,
        Editor = 8
    }
}
