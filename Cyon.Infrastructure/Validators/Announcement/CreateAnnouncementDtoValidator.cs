using Cyon.Domain.DTOs.Announcement;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Announcement
{
    public class CreateAnnouncementDtoValidator : AbstractValidator<CreateAnnouncementDto>
    {
        public CreateAnnouncementDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
        }
    }
}
