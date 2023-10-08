using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NameSurname { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

    }
}
