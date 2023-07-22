using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Finance;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Finance;
using Cyon.Domain.Services;
using Cyon.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class UserFinanceService : IUserFinanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;

        public UserFinanceService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, AppDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<UserFinanceModel> AddUserFinance(CreateUserFinanceDto userFinanceDto, Guid modifiedBy)
        {
            if (await IsSameExisting(userFinanceDto))
            {
                throw new BadRequestException("An exact finance seems to have been entered for this user today");
            }
            UserFinance userFinance = _mapper.Map<UserFinance>(userFinanceDto);
            userFinance.ModifiedBy = modifiedBy;
            userFinance.User = await _userManager.FindByIdAsync(userFinanceDto.UserId.ToString());

            await _unitOfWork.UserFinanceRepository.AddAsync(userFinance);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserFinanceModel>(userFinance);
        }

        public async Task PayDuesByAmount(PayDuesByAmountDto duesByAmountDto, Guid modifiedBy)
        {
            int numberOfMonths = duesByAmountDto.AmountPaid / duesByAmountDto.DuesCostMonthly;

            var lastPayment = await _dbContext.UserFinances
                .Where(x => x.Description.Contains("Monthly Due") && x.UserId == duesByAmountDto.UserId.ToString())
                .OrderByDescending(x => x.DateCollected)
                .FirstOrDefaultAsync();

            var user = await _userManager.FindByIdAsync(duesByAmountDto.UserId.ToString());

            if (lastPayment != null)
            {
                HashSet<UserFinance> userFinances = new();
                var dateCollected = lastPayment.DateCollected;

                for (int i = 1; i <= numberOfMonths; i++)
                {
                    UserFinance userFinance = new()
                    {
                        Description = "Monthly Due",
                        DateCollected = dateCollected.AddMonths(i),
                        Amount = duesByAmountDto.DuesCostMonthly,
                        ModifiedBy = modifiedBy,
                        FinanceType = "Pay",
                        User = user
                    };
                    userFinances.Add(userFinance);
                }

                await _unitOfWork.UserFinanceRepository.AddRangeAsync(userFinances);
            }
            else
            {
                HashSet<UserFinance> userFinances = new();

                var dateCollected = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 21);

                for (int i = 0; i < numberOfMonths; i++)
                {
                    UserFinance userFinance = new()
                    {
                        Description = "Monthly Due",
                        DateCollected = dateCollected.AddMonths(i),
                        Amount = duesByAmountDto.DuesCostMonthly,
                        ModifiedBy = modifiedBy,
                        FinanceType = "Pay",
                        User = user
                    };
                    userFinances.Add(userFinance);
                }
                await _unitOfWork.UserFinanceRepository.AddRangeAsync(userFinances);
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task PayDuesByMonths(PayDuesByMonthDto duesByMonthDto, Guid modifiedBy)
        {
            /*
             *  This feature is currently not available in any controller
             *  It intends to allow payment of dues by specifying a month range.
             */
            var startDate = new DateTime(duesByMonthDto.FromYear, duesByMonthDto.ToMonth, 21);
            var endDate = new DateTime(duesByMonthDto.ToYear, duesByMonthDto.ToMonth, 21);

            if (endDate < startDate)
            {
                throw new BadRequestException("start date cannot be greater than end date");
            }

            var user = await _userManager.FindByIdAsync(duesByMonthDto.UserId.ToString());

            HashSet<UserFinance> userFinances = new();

            for (int i = 0; startDate <= endDate; i++, startDate.AddMonths(i))
            {
                UserFinance userFinance = new()
                {
                    Description = duesByMonthDto.Description,
                    DateCollected = startDate,
                    Amount = duesByMonthDto.DuesCostMonthly,
                    ModifiedBy = modifiedBy,
                    User = user
                };
                userFinances.Add(userFinance);
            }

            await _unitOfWork.UserFinanceRepository.AddRangeAsync(userFinances);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserFinance(Guid id)
        {
            var userFinance = await _unitOfWork.UserFinanceRepository.GetByIdAsync(id);

            if (userFinance == null)
            {
                throw new NotFoundException("User finance record does not exist");
            }
            _unitOfWork.UserFinanceRepository.Delete(userFinance);
            await _unitOfWork.SaveAsync();
        }

        public async Task<UserFinanceModel> GetUserFinanceById(Guid id)
        {
            UserFinance userFinance = await _unitOfWork.UserFinanceRepository.GetByIdAsync(id);

            if (userFinance == null)
            {
                throw new NotFoundException("Finance record not found");
            }

            return _mapper.Map<UserFinanceModel>(userFinance);
        }


        public async Task<IEnumerable<UserFinanceModel>> GetUserFinances(Guid userId, Pagination pagination)
        {
            var filter = new List<Expression<Func<UserFinance, bool>>>
            {
                f => f.UserId == userId.ToString(),
                f => f.DateCollected.Year == DateTime.UtcNow.Year,
                f => f.DateCollected.Month <= DateTime.UtcNow.Month,
                f => f.Amount > 0
            };

            IEnumerable<UserFinance> userFinances = await _unitOfWork.UserFinanceRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);
            return _mapper.Map<IEnumerable<UserFinanceModel>>(userFinances.OrderByDescending(x => x.DateCollected));
        }

        public async Task UpdateUserFinance(UpdateUserFinanceDto userFinanceDto, Guid modifiedBy)
        {
            var userFinance = await _unitOfWork.UserFinanceRepository.GetByIdAsync(userFinanceDto.Id);
            userFinance.ModifiedBy = modifiedBy;
            if (userFinance == null)
            {
                throw new NotFoundException("User finance record does not exist");
            }
            _mapper.Map(userFinanceDto, userFinance);
            await _unitOfWork.UserFinanceRepository.UpdateAsync(userFinance);
            await _unitOfWork.SaveAsync();
        }

        public async Task<UserFinanceSummary> GetUserFinanceSummary(Guid userId)
        {
            return await _unitOfWork.UserFinanceRepository.GetUserFinanceSummary(userId);
        }

        public async Task<IEnumerable<UserFinanceModel>> GetDebts(Guid userId, Pagination pagination)
        {
            var filter = new List<Expression<Func<UserFinance, bool>>>
            {
                f => f.UserId == userId.ToString(),
                f => f.FinanceType == "Debt",
                f => f.Amount > 0
            };

            IEnumerable<UserFinance> userFinances = await _unitOfWork.UserFinanceRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<UserFinanceModel>>(userFinances.OrderByDescending(x => x.DateCollected));
        }

        public async Task ClearDebt(DebtPaymentDto debtPaymentDto, string ModifiedBy)
        {
            var filter = new List<Expression<Func<UserFinance, bool>>>
            {
                f => f.Id == debtPaymentDto.DebtId,
                f => f.FinanceType == "Debt"
            };

            var userFinance = await _unitOfWork.UserFinanceRepository.GetFirstMatchAsync(filter);

            if (userFinance == null)
            {
                throw new BadRequestException("Debt does not exist");
            }
            decimal amountRemaining = userFinance.Amount - debtPaymentDto.AmountToClear;
            if (amountRemaining < 0)
            {
                throw new BadRequestException("You cannot pay more than the remaining debt balance");
            }
            userFinance.Amount = amountRemaining; userFinance.LastModifiedBy = ModifiedBy; userFinance.DateModified = DateTime.UtcNow;

            await _unitOfWork.UserFinanceRepository.UpdateAsync(userFinance);

            int changes = await _unitOfWork.SaveAsync();

            if (changes > 0)
            {
                //Add it as Payment
                UserFinance userFinanceToAdd = _mapper.Map<UserFinance>(userFinance);
                userFinanceToAdd.Id = Guid.Empty;
                userFinanceToAdd.LastModifiedBy = ModifiedBy; userFinanceToAdd.Amount = debtPaymentDto.AmountToClear;
                userFinanceToAdd.Description = $"Paid {userFinance.Description}";
                userFinanceToAdd.CreatedBy = ModifiedBy; userFinanceToAdd.FinanceType = "Pay";
                userFinanceToAdd.User = await _userManager.FindByIdAsync(userFinanceToAdd.UserId.ToString());

                await _unitOfWork.UserFinanceRepository.AddAsync(userFinanceToAdd);
                await _unitOfWork.SaveAsync();
            }
        }

        private async Task<bool> IsSameExisting(CreateUserFinanceDto userFinanceDto)
        {
            return await _unitOfWork.UserFinanceRepository.ExistAsync(x => x.UserId == userFinanceDto.UserId.ToString() && x.Description == userFinanceDto.Description && x.DateCollected.Date == userFinanceDto.DateCollected.Date && x.Amount == userFinanceDto.Amount && x.FinanceType == userFinanceDto.FinanceType);
        }

        public async Task<IEnumerable<UserFinanceModel>> GetUserFinancesByDateRange(UserFinanceByDateDto userFinanceByDateDto)
        {
            return await _unitOfWork.UserFinanceRepository.GetUserFinancesByRange(userFinanceByDateDto.UserId, userFinanceByDateDto.StartDate, userFinanceByDateDto.EndDate);
        }
    }
}
