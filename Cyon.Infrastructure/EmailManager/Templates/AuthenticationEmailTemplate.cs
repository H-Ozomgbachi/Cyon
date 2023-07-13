using Cyon.Domain.Entities;

namespace Cyon.Infrastructure.EmailManager.Templates
{
    public class AuthenticationEmailTemplate
    {
        public static Message PasswordResetEmail(User user, string resetUrl, string token)
        {
            var message = new Message(new string[] { $"{user.Email}" }, "Forgot your password?", $"<p>Dear {user.FirstName} {user.LastName}, </p> <p>Did you forget your password ? Click on the link below to reset it.</p> <br/> <a href={$"{resetUrl}/{token}userEmail{user.Email}"} style={"background-color: blue;color: white;padding: 15px 25px;text-decoration: none; display: block; width: 50px; margin: 5px auto;"}>Reset Password</a> <br/> <p>If you did not ask to reset your password, please ignore this email and nothing will change.</p>", null);

            return message;
        }
    }
}
