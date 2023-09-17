namespace AppizsoftApp.Application.Exceptions.AuthExceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException(string email)
            : base($"Bu e-posta adresi zaten kullanılıyor: {email}")
        {
        }
    }
}
