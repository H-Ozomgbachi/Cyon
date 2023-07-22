using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Finance;
using Cyon.Domain.Models.Finance;

namespace Cyon.Domain.Services
{
    public interface IUserFinanceService
    {
        Task<IEnumerable<UserFinanceModel>> GetUserFinances(Guid userId, Pagination pagination);
        Task<UserFinanceModel> GetUserFinanceById(Guid id);
        Task<UserFinanceModel> AddUserFinance(CreateUserFinanceDto userFinanceDto, Guid modifiedBy);
        Task UpdateUserFinance(UpdateUserFinanceDto userFinanceDto, Guid modifiedBy);
        Task DeleteUserFinance(Guid id);
        Task PayDuesByMonths(PayDuesByMonthDto duesByMonthDto, Guid modifiedBy);
        Task PayDuesByAmount(PayDuesByAmountDto duesByAmountDto, Guid modifiedBy);
        Task<UserFinanceSummary> GetUserFinanceSummary(Guid userId);
        Task<IEnumerable<UserFinanceModel>> GetDebts(Guid userId, Pagination pagination);
        Task ClearDebt(DebtPaymentDto debtPaymentDto, string ModifiedBy);
        Task<IEnumerable<UserFinanceModel>> GetUserFinancesByDateRange(UserFinanceByDateDto userFinanceByDateDto);
    }
}