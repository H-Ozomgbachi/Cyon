using Cyon.Domain.DTOs.Attendance;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Attendance
{
    public class CreateApologyValidator : AbstractValidator<CreateApologyDto>
    {
        public CreateApologyValidator()
        {
            RuleFor(x => x.AttendanceTypeId).NotEmpty().WithMessage("Event for apology is required");
            RuleFor(x => x.AbsenteeReason).NotEmpty().WithMessage("Reason to be absent is required").MaximumLength(100).WithMessage("Your reason cannot exceed 100 characters");
            RuleFor(x => x.Date).Must(x => DateTime.Now.Date == x.Date).WithMessage("You cannot send apology for past or previous day's event");
        }
    }
}
