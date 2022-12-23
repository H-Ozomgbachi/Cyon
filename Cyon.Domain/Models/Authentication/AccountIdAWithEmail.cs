namespace Cyon.Domain.Models.Authentication
{
    public struct AccountIdAWithEmail
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
