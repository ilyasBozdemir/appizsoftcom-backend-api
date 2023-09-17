using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Exceptions.AuthExceptions;
using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
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
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authRepository.UserExists(request.UserName);

            if (!result)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                request.PasswordSalt = passwordSalt;
                request.PasswordHash = passwordHash;

                var user = _mapper.Map<User>(request);
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

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
