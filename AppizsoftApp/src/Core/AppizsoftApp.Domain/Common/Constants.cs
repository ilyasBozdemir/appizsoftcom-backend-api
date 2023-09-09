using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Domain.Common
{
    namespace YourApp.Domain.Common
    {
        public static class Constants
        {
            // Kullanıcı rolleri için sabitler
            public const string AdminRole = "Admin";
            public const string UserRole = "User";

            // Uygulama ayarları için sabitler
            public const string AppName = "Appizsoft Yazılım";
            public const int DefaultPageSize = 10;

            // Diğer sabitler
            public const int MaxUserNameLength = 50;
            public const int MaxEmailLength = 100;
        }
    }

}
