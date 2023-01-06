using Cyon.Domain.Models.Authentication;

namespace Cyon.Domain.Models.AccountManagement
{
    public class GroupedUsersModel
    {
        public string GroupTitle { get; set; }
        public IEnumerable<AccountModel> Members { get; set; }
    }
}
