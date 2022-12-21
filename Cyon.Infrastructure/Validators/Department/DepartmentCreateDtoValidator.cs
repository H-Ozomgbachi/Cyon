using Cyon.Domain.DTOs.Department;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Department
{
    public class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Department name cannot be empty");
        }
    }
}
