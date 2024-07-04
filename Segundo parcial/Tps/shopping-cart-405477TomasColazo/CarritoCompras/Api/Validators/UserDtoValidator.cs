using Api.Dtos;
using FluentValidation;

namespace Api.Validators
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Debe ingresar un mail valido");
        }
    }
}
