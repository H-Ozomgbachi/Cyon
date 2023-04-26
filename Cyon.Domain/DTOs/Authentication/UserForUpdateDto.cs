namespace Cyon.Domain.DTOs.Authentication
{
    public class UserForUpdateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public bool IsCommunicant { get; set; }
        public string Address { get; set; }
    }
}
