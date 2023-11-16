using AppizsoftApp.Application.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace AppizsoftApp.Application.Features.Commands.AppUser.CreateUser
{
    /// <summary>
    /// Kullanıcı kaydı komutu için istek nesnesini temsil eden sınıf.
    /// </summary>
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

}
