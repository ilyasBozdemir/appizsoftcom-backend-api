namespace AppizsoftApp.Application.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string email)
            : base($"Bu e-posta adresi zaten kullanılıyor: {email}")
        {
        }
    }
}
