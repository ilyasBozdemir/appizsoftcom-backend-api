using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Exceptions.UserExceptions
{
    public class EmptyUserException : Exception
    {
        public EmptyUserException(string message)
            : base($"EmptyUserException: {message}")
        {
        }
    }

}
