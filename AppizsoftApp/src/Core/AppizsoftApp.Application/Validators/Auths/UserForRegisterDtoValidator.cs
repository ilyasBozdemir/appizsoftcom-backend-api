using AppizsoftApp.Application.Dtos.Auth;
using FluentValidation;

namespace AppizsoftApp.Application.Validators.Auths
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(dto => dto.UserName)
           .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
           .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter içermelidir.")
           .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter içermelidir.")
           .Matches("^[a-zA-Z0-9]*$").WithMessage("Kullanıcı adı yalnızca harf ve rakam içerebilir.");


            RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("E-posta boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır");
        }
    }

}
