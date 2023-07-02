using Cyon.Domain.DTOs.UpcomngEvent;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.UpcomingEvent
{
    public class UpdateUpcomingEventDtoValidator : AbstractValidator<UpdateUpcomingEventDto>
    {
        public UpdateUpcomingEventDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
