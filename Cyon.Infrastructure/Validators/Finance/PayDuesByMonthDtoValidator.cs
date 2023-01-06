using Cyon.Domain.DTOs.Finance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Finance
{
    public class PayDuesByMonthDtoValidator : AbstractValidator<PayDuesByMonthDto>
    {
        public PayDuesByMonthDtoValidator()
        {
            RuleFor(x => x.FromMonth).GreaterThanOrEqualTo(1).LessThanOrEqualTo(12).WithMessage("Month number must be between 1 and 12");
            RuleFor(x => x.ToMonth).GreaterThanOrEqualTo(1).LessThanOrEqualTo(12).WithMessage("Month number must be between 1 and 12");
            RuleFor(x => x.FromYear).GreaterThanOrEqualTo(2000);
            RuleFor(x => x.ToYear).GreaterThanOrEqualTo(2000);
        }
    }
}
