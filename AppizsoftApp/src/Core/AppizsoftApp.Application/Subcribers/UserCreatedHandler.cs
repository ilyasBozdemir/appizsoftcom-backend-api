using AppizsoftApp.Application.Events;
using AppizsoftApp.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AppizsoftApp.Application.Subcribers
{
    public class UserCreatedHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        public UserCreatedHandler(IUserRepository userRepository, ILogger<UserCreatedHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(notification.UserId);

            if (user == null)
            {
                Console.WriteLine($"User not found by user id: {notification.UserId} from publisher");
                // Kullanıcı bulunamadı hatasıyla ilgili ek işlem veya istisna fırlatma işlemleri yapılabilir.
            }
            else
            {
                Console.WriteLine($"User found by user id: {notification.UserId} from publisher");
                // Kullanıcı bulunduğunda yapılacak işlemler buraya eklenir.
            }


        }
    }
}
