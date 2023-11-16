namespace AppizsoftApp.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message)
            : base($"{message}")
        {
        }
        public UserNotFoundException() : base("Kullanıcı adı veya şifre hatalı.")
        {
        }
    }
}
