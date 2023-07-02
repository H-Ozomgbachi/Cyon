using Cyon.Domain.DTOs.UpcomngEvent;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.UpcomingEvent
{
    public class CreateUpcomingEventDtoValidator : AbstractValidator<CreateUpcomingEventDto>
    {
        public CreateUpcomingEventDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Image).NotNull();
        }
    }
}
