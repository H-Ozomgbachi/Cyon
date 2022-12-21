using Cyon.Domain.DTOs.Minutes;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Minutes
{
    public class UpdateMinutesDtoValidator : AbstractValidator<UpdateMinuteDto>
    {
        public UpdateMinutesDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Minutes content is required");
        }
    }
}
