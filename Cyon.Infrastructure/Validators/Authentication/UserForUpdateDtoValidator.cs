using Cyon.Domain.DTOs.Authentication;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Authentication
{
    public class UserForUpdateDtoValidator : AbstractValidator<UserForUpdateDto>
    {
        public UserForUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
