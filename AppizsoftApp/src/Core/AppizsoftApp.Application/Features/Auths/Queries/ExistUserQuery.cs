using AppizsoftApp.Application.Interfaces.Repositories;
using MediatR;
namespace AppizsoftApp.Application.Features.Users.Queries
{
    /* ExistUserQuery ilgili controller ile cagrılır query oldugu belli olsun diye Query ile biter.
     * IRequest<bool>  arabirimini uygular bool yani kullanıcı var yok anlamında true veya false dönmesi için.
     * mediatr nesnesine _mediator.Send(query); diye gönderdik ya.
     * IRequest'ten türediği için  IRequestHandler içinde ilgili query sınıfını arar.
     * IRequestHandler<ExistUserQuery, bool> olarak işlendiği için
       ExistUserQueryHandler sınıfında ki Handle methodunu cagırır. Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
      ile gönderilen request'i burda alır ve işler


     * Diğer konu da aşagıda ki gibidir. 
    IUserRepositoryEF ve IUserRepositoryDapper zaten IUserRepository'dan miras alıyor.
    Dependency Injection (DI) ile;
    // Entity Framework kullanmak için IUserRepository'yi kaydetme
       
    services.AddScoped<IUserRepository, UserRepositoryEF>();
    // UserRepositoryEF, IUserRepositoryEF arayüzünü uygulayan bir sınıf olmalı
    //servise diyorsun her HTTP isteği için yeni bir hizmet örneği oluştur
    ve bu isteğin ömrü boyunca aynı örneği kullan diye o yüzden AddScoped ile ekliyoruz
    tabi bunu ilgili katmanın ServiceRegistration.cs içinde yapcaz
    yani servise diyorsun senden IUserRepository istersem bana UserRepositoryEF
    bundan bir nesne ver.

    // Dapper kullanmak için IUserRepository'yi kaydetme
    services.AddScoped<IUserRepository, UserRepositoryDapper>(); 
    // UserRepositoryDapper, IUserRepositoryDapper arayüzünü uygulayan bir sınıf olmalı */
    public class ExistUserQuery : IRequest<bool>
    {
        public Guid UserId { get; set; }
    }
    public class ExistUserQueryHandler : IRequestHandler<ExistUserQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        /*
        public ExistUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        */
        public async Task<bool> Handle(ExistUserQuery request, CancellationToken cancellationToken)
        {
          //  var user = await _userRepository.GetByIdAsync(request.UserId);
            return true;
        }
    }
}
