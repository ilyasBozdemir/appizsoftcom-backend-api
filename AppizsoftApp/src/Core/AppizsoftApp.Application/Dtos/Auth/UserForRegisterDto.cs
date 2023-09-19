using AppizsoftApp.Application.Enums;

namespace AppizsoftApp.Application.Dtos.Auth
{
    public class UserForRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
        public List<Roles> Roles { get; set; }
    }
}
