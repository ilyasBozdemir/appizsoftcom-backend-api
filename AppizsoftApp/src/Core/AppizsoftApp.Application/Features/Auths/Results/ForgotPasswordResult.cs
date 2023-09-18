using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Results
{
    public class ForgotPasswordResult
    {
        public bool IsSuccessful { get; set; }
        public string ResetToken { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
