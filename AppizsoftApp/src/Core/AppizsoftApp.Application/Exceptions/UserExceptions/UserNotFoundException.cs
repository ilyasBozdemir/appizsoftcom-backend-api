

namespace AppizsoftApp.Application.Exceptions.UserExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base($"UserNotFoundException: {message}")
        {
        }
    }
}
