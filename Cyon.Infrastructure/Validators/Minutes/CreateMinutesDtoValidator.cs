using Cyon.Domain.DTOs.Minutes;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Minutes
{
    public class CreateMinutesDtoValidator : AbstractValidator<CreateMinuteDto>
    {
        public CreateMinutesDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Minutes content is required");
        }
    }
}
