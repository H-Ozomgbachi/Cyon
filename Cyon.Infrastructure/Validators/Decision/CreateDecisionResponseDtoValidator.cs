using Cyon.Domain.DTOs.Decision;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Decision
{
    public class CreateDecisionResponseDtoValidator : AbstractValidator<CreateDecisionResponseDto>
    {
        public CreateDecisionResponseDtoValidator()
        {
            RuleFor(x => x.Response)
                .NotEmpty().WithMessage("Response is required")
                .MaximumLength(100);
        }
    }
}
