using Cyon.Domain.DTOs.Meeting;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Meeting
{
    public class CreateMeetingDtoValidator : AbstractValidator<CreateMeetingDto>
    {
        public CreateMeetingDtoValidator()
        {
            RuleFor(x => x.ProposedDurationInMinutes).NotNull().NotEmpty();
            RuleFor(x => x.Agenda.Select(x => x.Title)).NotEmpty();
            RuleFor(x => x.Agenda.Select(x => x.Description)).NotEmpty();
        }
    }
}
