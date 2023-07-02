using Cyon.Domain.DTOs.Announcement;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Announcement
{
    public class UpdateAnnouncementDtoValidator : AbstractValidator<UpdateAnnouncementDto>
    {
        public UpdateAnnouncementDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100);
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Active status is required");
        }
    }
}
