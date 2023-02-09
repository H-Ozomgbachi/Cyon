using Cyon.Domain.Models.Department;

namespace Cyon.Domain.Models.Authentication
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public IList<string> Roles { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public bool IsCommunicant { get; set; }
        public DepartmentModel Department { get; set; }
        public string Rank { get; set; }
        public string Address { get; set; }
    }
}
