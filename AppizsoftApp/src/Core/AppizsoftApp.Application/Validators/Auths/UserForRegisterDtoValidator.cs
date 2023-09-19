using AppizsoftApp.Application.Dtos.Auth;
using FluentValidation;

namespace AppizsoftApp.Application.Validators.Auths
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
           
            RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("E-posta boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır");
        }
    }

}
