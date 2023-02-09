using Microsoft.AspNetCore.Identity;

namespace Cyon.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; } = "https://api-private.atlassian.com/users/8f525203adb5093c5954b43a5b6420c2/avatar";
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsCommunicant { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Rank { get; set; } = "Regular";
        public bool IsActive { get; set; } = true;
        public string InactiveReason { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime LastModified { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime LastLogin { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Apology> Apologies { get; set; }
        public ICollection<UserFinance> UserFinances { get; set; }
    }
}