

namespace AppizsoftApp.Application.Exceptions.UserExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid userId)
            : base($"Kullanıcı bulunamadı. Kimlik: {userId}")
        {
        }
    }
}
