namespace Cyon.Domain.DTOs.AccountManagement
{
    public class DeactivateAccountDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ReasonToDeactivate { get; set; }
        public string Phone { get; set; }
    }
}
