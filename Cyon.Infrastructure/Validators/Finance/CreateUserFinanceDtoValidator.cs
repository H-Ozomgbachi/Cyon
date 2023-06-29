using Cyon.Domain.DTOs.Finance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Finance
{
    public class CreateUserFinanceDtoValidator : AbstractValidator<CreateUserFinanceDto>
    {
        private readonly List<string> _financeTypes = new() { "Pay", "Debt" };
        public CreateUserFinanceDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Amount).NotEqual(0);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.FinanceType)
                .NotEmpty().WithMessage("Finance type is required")
                .MaximumLength(12).WithMessage("Not more than 4 characters")
                .Must(x => _financeTypes.Contains(x)).WithMessage("Finance type can only be either Pay or Debt");
        }
    }
}
