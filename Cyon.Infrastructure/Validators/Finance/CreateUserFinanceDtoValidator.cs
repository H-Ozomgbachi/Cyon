using Cyon.Domain.DTOs.Finance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Finance
{
    public class CreateUserFinanceDtoValidator : AbstractValidator<CreateUserFinanceDto>
    {
        public CreateUserFinanceDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Amount).NotEqual(0);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
