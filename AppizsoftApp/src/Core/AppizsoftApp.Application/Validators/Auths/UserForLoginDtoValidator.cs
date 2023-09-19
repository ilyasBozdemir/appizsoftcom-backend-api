using FluentValidation;
using AppizsoftApp.Application.Dtos.Auth;

namespace AppizsoftApp.Application.Validators.Auths
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(dto => dto.Email)
                       .NotEmpty().WithMessage("E-posta boş olamaz.")
                       .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır");


        }
    }
}
