namespace AppizsoftApp.Application.Exceptions.AuthExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base($"UserNotFoundException: {message}")
        {
        }
    }
}
