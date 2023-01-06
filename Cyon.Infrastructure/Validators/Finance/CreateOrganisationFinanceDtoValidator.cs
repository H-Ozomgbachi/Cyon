using Cyon.Domain.DTOs.Finance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Finance
{
    public class CreateOrganisationFinanceDtoValidator : AbstractValidator<CreateOrganisationFinanceDto>
    {
        private readonly List<string> _financeTypes = new() { "Income", "Expenditure" };
        public CreateOrganisationFinanceDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(x => x.FinanceType)
                .NotEmpty().WithMessage("Finance type is required")
                .MaximumLength(12).WithMessage("Not more than 12 characters")
                .Must(x => _financeTypes.Contains(x)).WithMessage("Finance type can only be either Income or Expenditure");

            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}
