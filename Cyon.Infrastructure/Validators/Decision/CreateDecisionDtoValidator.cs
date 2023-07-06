using Cyon.Domain.DTOs.Decision;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Decision
{
    public class CreateDecisionDtoValidator : AbstractValidator<CreateDecisionDto>
    {
        public CreateDecisionDtoValidator()
        {
            RuleFor(x => x.Question).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Options).Must(x => x.Count > 0).WithMessage("Options must be provided");
        }
    }
}
