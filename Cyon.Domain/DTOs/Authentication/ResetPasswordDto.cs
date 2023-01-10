namespace Cyon.Domain.DTOs.Authentication
{
    public class ResetPasswordDto
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
