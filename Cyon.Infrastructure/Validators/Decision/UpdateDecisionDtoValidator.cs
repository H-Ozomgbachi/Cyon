using Cyon.Domain.DTOs.Decision;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Decision
{
    public class UpdateDecisionDtoValidator : AbstractValidator<UpdateDecisionDto>
    {
        public UpdateDecisionDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Question).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Options).NotEmpty().WithMessage("Options must be provided");
        }
    }
}
