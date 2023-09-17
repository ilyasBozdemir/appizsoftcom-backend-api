using AppizsoftApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Results
{
    public class CreateUserResult 
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
