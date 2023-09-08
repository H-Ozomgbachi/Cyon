using Cyon.Domain.DTOs.Biz;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Biz
{
    public class CreateBizDtoValidator : AbstractValidator<CreateBizDto>
    {
        public CreateBizDtoValidator()
        {
            RuleFor(x => x.BusinessName)
                .NotEmpty().WithMessage("Business name is required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Length(11).WithMessage("Phone must be 11 digit long");
            RuleFor(x => x.EmailAddress)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Must be a valid email");
            RuleFor(x => x.PhysicalAddress)
                .NotEmpty().WithMessage("Address is required");
        }
    }
}
