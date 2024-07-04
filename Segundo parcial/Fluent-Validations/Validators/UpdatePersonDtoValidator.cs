using FluentValidation;
using PersonsApi.Dto;

namespace PersonsApi.Validators
{
    public class UpdatePersonDtoValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonDtoValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => Guid.TryParse(x, out var guid))
                    .WithMessage("El formato del Id debe ser de tipo Guid");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(5).WithMessage("El largo debe ser mayor a 5");
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
