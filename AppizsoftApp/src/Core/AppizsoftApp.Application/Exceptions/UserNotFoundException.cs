namespace AppizsoftApp.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base($"UserNotFoundException: {message}")
        {
        }
    }
}
