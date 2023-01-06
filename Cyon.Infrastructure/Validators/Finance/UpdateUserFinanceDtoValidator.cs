using Cyon.Domain.DTOs.Finance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Finance
{
    public class UpdateUserFinanceDtoValidator : AbstractValidator<UpdateUserFinanceDto>
    {
        public UpdateUserFinanceDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Amount).NotEqual(0);
        }
    }
}
