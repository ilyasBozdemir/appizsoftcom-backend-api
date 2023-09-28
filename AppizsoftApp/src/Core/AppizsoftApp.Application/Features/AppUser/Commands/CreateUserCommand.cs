using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Exceptions.AuthExceptions;
using AppizsoftApp.Application.Features.AppUser.Results;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.AppUser.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<Roles> Roles { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {

        private readonly IAuthRepository _authRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IAuthRepository authRepository, IMapper mapper, IPasswordService passwordService)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authRepository.UserExists(request.Email);

            if (!result)
            {
                byte[] passwordHash, passwordSalt;

                _passwordService. CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                request.PasswordSalt = passwordSalt;
                request.PasswordHash = passwordHash;

                var user = _mapper.Map<User>(request);
                user.UserId = Guid.NewGuid();
                user.CreatedAt = DateTime.Now;

                var createdUser = await _authRepository.Register(user, request.Password);

                return new CreateUserResult
                {
                    Message = "Kullanıcı Başarıyla oluşturuldu.",
                    StatusCode = 201,
                    User = createdUser,
                };
            }

            else
            {
                return new CreateUserResult
                {
                    Message = "Kullanıcı zaten kayıtlı.",
                    StatusCode = 409,
                };
            }
        }
    }
}
