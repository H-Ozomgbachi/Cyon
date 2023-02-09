using Cyon.Domain.DTOs.YearProgramme;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.YearProgramme
{
    public class CreateYearProgrammeDtoValidator : AbstractValidator<CreateYearProgrammeDto>
    {
        public CreateYearProgrammeDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100).WithMessage("Title cannot be more than 100 characters");
        }
    }
}
