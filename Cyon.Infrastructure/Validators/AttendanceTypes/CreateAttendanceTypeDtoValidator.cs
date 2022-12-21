using Cyon.Domain.DTOs.Attendance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.AttendanceTypes
{
    public class CreateAttendanceTypeDtoValidator : AbstractValidator<CreateAttendanceTypeDto>
    {
        public CreateAttendanceTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("Attendance type name cannot be more than 100 characters");
        }
    }
}
