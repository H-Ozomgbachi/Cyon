using Cyon.Domain.DTOs.Finance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Finance
{
    public class PayDuesByAmountDtoValidator : AbstractValidator<PayDuesByAmountDto>
    {
        public PayDuesByAmountDtoValidator()
        {
            RuleFor(x => x.DuesCostMonthly).GreaterThan(0);
            RuleFor(x => x.AmountPaid % x.DuesCostMonthly).Equal(0).WithMessage("Amount paid must be divisible by the monthly cost of dues");
        }
    }
}
