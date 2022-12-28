using Cyon.Domain.DTOs.Attendance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Attendance
{
    public class UpdateAttendanceTypeDtoValidator : AbstractValidator<UpdateAttendanceTypeDto>
    {
        public UpdateAttendanceTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("Attendance type name cannot be more than 100 characters");
        }
    }
}
