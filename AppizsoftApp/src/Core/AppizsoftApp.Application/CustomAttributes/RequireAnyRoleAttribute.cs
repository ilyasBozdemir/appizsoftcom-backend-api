using AppizsoftApp.Application.Enums;
using Microsoft.AspNetCore.Authorization;

namespace AppizsoftApp.Application.CustomAttributes
{
    public class RequireAnyRoleAttribute : AuthorizeAttribute
    {
        public RequireAnyRoleAttribute(Roles roles)
        {
            Roles = roles.ToString();
        }
    }
}
