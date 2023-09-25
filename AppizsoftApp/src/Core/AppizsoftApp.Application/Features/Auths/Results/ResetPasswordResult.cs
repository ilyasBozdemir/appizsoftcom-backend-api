using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Results
{
    public class ResetPasswordResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResetPasswordResult()
        {

        }
        public ResetPasswordResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
      
    }
}
