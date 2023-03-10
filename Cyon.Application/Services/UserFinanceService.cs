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

            var lastPayment = await _dbContext.UserFinances.OrderByDescending(x => x.DateCollected).FirstOrDefaultAsync();

            var user = await _userManager.FindByIdAsync(duesByAmountDto.UserId.ToString());

            if (lastPayment != null)
            {
                HashSet<UserFinance> userFinances = new();
                var dateCollected = lastPayment.DateCollected;

                for (int i = 1; i <= numberOfMonths; i++)
                {
                    UserFinance userFinance = new()
                    {
                        Description = duesByAmountDto.Description,
                        DateCollected = dateCollected.AddMonths(i),
                        Amount = duesByAmountDto.DuesCostMonthly,
                        ModifiedBy = modifiedBy,
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
                        Description = duesByAmountDto.Description,
                        DateCollected = dateCollected.AddMonths(i),
                        Amount = duesByAmountDto.DuesCostMonthly,
                        ModifiedBy = modifiedBy,
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
                throw new ConflictException("start date cannot be greater than end date");
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
                f => f.UserId == userId.ToString()
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
    }
}
