using FluentValidation;
using AppizsoftApp.Application.Dtos.Auth;

namespace AppizsoftApp.Application.Validators.Auths
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(dto => dto.UserName)
         .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
         .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter içermelidir.")
         .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter içermelidir.")
         .Matches("^[a-zA-Z0-9]*$").WithMessage("Kullanıcı adı yalnızca harf ve rakam içerebilir.");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır");


        }
    }
}
