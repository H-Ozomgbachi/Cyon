using Cyon.Domain.DTOs.Chaplain;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Chaplain
{
    public class ChaplainUpdateDtoValidator : AbstractValidator<ChaplainUpdateDto>
    {
        public ChaplainUpdateDtoValidator()
        {
            RuleFor(c => c.FullName).NotEmpty().WithMessage("Chaplain's full name is required");
            RuleFor(c => c.ImageUrl).NotEmpty().WithMessage("Chaplain's photo is required");
            RuleFor(c => c.StartYear).NotEmpty().WithMessage("Start year is required").MaximumLength(4).WithMessage("Start year must not be more than 4 characters");
            RuleFor(c => c.EndYear).NotEmpty().WithMessage("End year is required").MaximumLength(7).WithMessage("End year must not be more than 7 characters");
        }
    }
}
