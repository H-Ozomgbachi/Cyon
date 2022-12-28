using Cyon.Domain.DTOs.AccountManagement;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.AccountManagement
{
    public class DeactivateAccountDtoValidator : AbstractValidator<DeactivateAccountDto>
    {
        public DeactivateAccountDtoValidator()
        {
            RuleFor(x => x.ReasonToDeactivate).NotEmpty().WithMessage("Reason to deactivate is required");
        }
    }
}
