using Cyon.Domain.DTOs.AccountManagement;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.AccountManagement
{
    public class RequestToDeactivateDtoValidator : AbstractValidator<RequestToDeactivateDto>
    {
        public RequestToDeactivateDtoValidator()
        {
            RuleFor(x => x.Reason).NotEmpty().WithMessage("Deactivation reason is required");
        }
    }
}
