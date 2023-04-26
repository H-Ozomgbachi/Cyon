using Cyon.Domain.Entities;
using Cyon.Domain.Models.Finance;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cyon.Infrastructure.Repositories
{
    public class OrganisationFinanceRepository : Repository<OrganisationFinance>, IOrganisationFinanceRepository
    {
        private readonly DapperContext _dapperContext;

        public OrganisationFinanceRepository(DbSet<OrganisationFinance> organisationFinances, DapperContext dapperContext) : base(organisationFinances)
        {
            _dapperContext = dapperContext;
        }

        public async Task<decimal> GetOrganisationFinanceBalance()
        {
            string sp = "Sp_GetOrganisationFinanceBalance";
            decimal balance = 0;

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<IncomeExpenditure>(sp);

                balance = result.TotalIncome - result.TotalExpenditure;
            }

            return balance;
        }

        public Task<OrganizationAccountBalance> GetOrganizationAccountBalance()
        {
            throw new NotImplementedException();
        }

        public async Task<OrganisationAccountStatementModel> GetStatementOfAccount(DateTime startDate, DateTime endDate)
        {
            string sp1 = "Sp_GetBalanceBroughtForward";
            string sp2 = "Sp_GetFinancesForGivenDateRange";

            using var connection = _dapperContext.CreateConnection();

            var parameters1 = new DynamicParameters();
            parameters1.Add("StartDate", startDate, DbType.DateTime, ParameterDirection.Input);
            parameters1.Add("EndDate", endDate, DbType.DateTime, ParameterDirection.Input);

            var previousBalance = await connection.QueryFirstAsync<PreviousBalance>(sp1, parameters1, commandType: CommandType.StoredProcedure);

            var finances = await connection.QueryAsync<OrganisationFinanceModel>(sp2, parameters1, commandType: CommandType.StoredProcedure);

            decimal totalIncome = finances.Where(x => x.FinanceType == "Income").Sum(s => s.Amount);
            decimal totalExpenditure = finances.Where(x => x.FinanceType == "Expenditure").Sum(s => s.Amount);

            var statementOfAccount = new OrganisationAccountStatementModel
            {
                StartDate = startDate.ToShortDateString(),
                EndDate = endDate.ToShortDateString(),
                BalanceBroughtForward = previousBalance.BalanceBroughtForward,
                Finances = finances,
                BalanceAtHand = (totalIncome + previousBalance.BalanceBroughtForward) - totalExpenditure,
            };

            return statementOfAccount;
        }
    }

    public class IncomeExpenditure
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenditure { get; set; }
    }
    public class PreviousBalance
    {
        public decimal BalanceBroughtForward { get; set; }
    }
}
