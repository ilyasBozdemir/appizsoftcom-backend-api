using Microsoft.AspNetCore.Identity;

namespace AppizsoftApp.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
