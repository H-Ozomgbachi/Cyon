using Cyon.Domain.DTOs.Occupation;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Occupation
{
    public class CreateOccupationDtoValidator : AbstractValidator<CreateOccupationDto>
    {
        public CreateOccupationDtoValidator()
        {
            When(x => x.IsStudent || !x.IsUnemployed, () =>
            {
                RuleFor(x => x.JobTitle).NotEmpty().WithMessage("Job title or course of study is required").MaximumLength(100).WithMessage("Job title or course of study cannot be more than 100 characters");

                RuleFor(x => x.Company).NotEmpty().WithMessage("Company or school name is required").MaximumLength(100).WithMessage("Company or school name cannot be more than 100 characters");
            });
            When(x => x.IsUnemployed, () =>
            {
                RuleFor(x => x.CanDo).NotEmpty().WithMessage("Please specify which job you can do");
            });
        }
    }
}
