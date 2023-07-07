namespace Cyon.Domain.DTOs.AccountManagement
{
    public class GenerateRandomUserGroupsDto
    {
        public IEnumerable<string> GroupTitles { get; set; }
        public int NumberOfUsersPerGroup { get; set; }
    }
}