using Cyon.Domain.DTOs.Authentication;
using FluentValidation;

namespace Cyon.Infrastructure.Validators.Authentication
{
    public class UserForRegistrationValidator : AbstractValidator<UserForRegistrationDto>
    {
        public UserForRegistrationValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required and be valid");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
            RuleFor(x => x.DateOfBirth).NotNull().WithMessage("Date of birth is required");
        }
    }

    public class UserForAuthenticationValidator : AbstractValidator<UserForAuthenticationDto>
    {
        public UserForAuthenticationValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Must be a valid email address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }

    public class ForgotPasswordDtoValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Must be a valid email address");
        }
    }

    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(x => x.NewPassword).NotEmpty();
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage("Passwords do not match");
        }
    }
}
