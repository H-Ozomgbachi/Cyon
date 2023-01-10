namespace Cyon.Domain.Models.Authentication
{
    public class AccountModelConcise
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string PhoneNumber { get; set; }
    }
}
