using Cyon.Domain.DTOs.Department;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Department
{
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Department name cannot be empty");
        }
    }
}
