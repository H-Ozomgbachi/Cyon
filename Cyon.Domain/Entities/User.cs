using Microsoft.AspNetCore.Identity;

namespace Cyon.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; } = "https://api-private.atlassian.com/users/8f525203adb5093c5954b43a5b6420c2/avatar";
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Rank { get; set; } = "Regular";
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
