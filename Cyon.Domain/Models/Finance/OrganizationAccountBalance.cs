namespace Cyon.Domain.Models.Finance
{
    public class OrganizationAccountBalance
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenditure { get; set; }
        public decimal Balance => TotalIncome - TotalExpenditure;
    }
}
