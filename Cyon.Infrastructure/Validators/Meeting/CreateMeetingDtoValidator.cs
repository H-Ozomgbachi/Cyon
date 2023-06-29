using Cyon.Domain.DTOs.Meeting;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Meeting
{
    public class CreateMeetingDtoValidator : AbstractValidator<CreateMeetingDto>
    {
        public CreateMeetingDtoValidator()
        {
        }
    }
}
