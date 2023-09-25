using AppizsoftApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Results
{
    public class CheckSessionResult
    {
        public bool AuthenticateResult { get; set; }
        public object Data { get; set; }
    }
}
