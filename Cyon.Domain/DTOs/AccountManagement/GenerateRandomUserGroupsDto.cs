namespace Cyon.Domain.DTOs.AccountManagement
{
    public class GenerateRandomUserGroupsDto
    {
        public IEnumerable<string> GroupTitles { get; set; }
        public int NumberOfUsersPerGroup { get; set; }
        public IEnumerable<Guid> ExemptUsers { get; set; }
        public bool ConsiderAllActiveUsers { get; set; }
    }
}