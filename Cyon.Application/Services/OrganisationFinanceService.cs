using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Finance;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Finance;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class OrganisationFinanceService : IOrganisationFinanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrganisationFinanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrganisationFinanceModel> AddOrganisationFinance(CreateOrganisationFinanceDto organisationFinanceDto, Guid modifiedBy)
        {
            OrganisationFinance organisationFinance = _mapper.Map<OrganisationFinance>(organisationFinanceDto);
            organisationFinance.ModifiedBy = modifiedBy;

            await _unitOfWork.OrganisationFinanceRepository.AddAsync(organisationFinance);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrganisationFinanceModel>(organisationFinance);
        }

        public async Task DeleteOrganisationFinance(Guid id)
        {
            OrganisationFinance organisationFinance = await _unitOfWork.OrganisationFinanceRepository.GetByIdAsync(id);

            if (organisationFinance == null)
            {
                throw new NotFoundException($"Organisation finance with id: {id} not found");
            }

            await _unitOfWork.OrganisationFinanceRepository.DeleteAsync(organisationFinance);
            await _unitOfWork.SaveAsync();
        }

        public async Task<OrganisationAccountStatementModel> GetOrganisationAccountStatement(GetAccountStatementDto accountStatementDto)
        {
            return await _unitOfWork.OrganisationFinanceRepository.GetStatementOfAccount(accountStatementDto.StartDate, accountStatementDto.EndDate);
        }

        public async Task<OrganisationFinanceModel> GetOrganisationFinance(Guid id)
        {
            OrganisationFinance organisationFinance = await _unitOfWork.OrganisationFinanceRepository.GetByIdAsync(id);

            if (organisationFinance == null)
            {
                throw new NotFoundException($"Organisation finance with id: {id} not found");
            }

            return _mapper.Map<OrganisationFinanceModel>(organisationFinance);
        }

        public async Task<decimal> GetOrganisationFinanceBalance()
        {
            return await _unitOfWork.OrganisationFinanceRepository.GetOrganisationFinanceBalance();
        }

        public async Task<IEnumerable<OrganisationFinanceModel>> GetOrganisationFinances(Pagination pagination)
        {
            IEnumerable<OrganisationFinance> organisationFinances = await _unitOfWork.OrganisationFinanceRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<OrganisationFinanceModel>>(organisationFinances);
        }

        public async Task UpdateOrganisationFinance(UpdateOrganisationFinanceDto organisationFinanceDto, Guid modifiedBy)
        {
            OrganisationFinance organisationFinance = await _unitOfWork.OrganisationFinanceRepository.GetByIdAsync(organisationFinanceDto.Id);

            if (organisationFinance == null)
            {
                throw new NotFoundException($"Organisation finance with id: {organisationFinanceDto.Id} not found");
            }

            _mapper.Map(organisationFinanceDto, organisationFinance);
            organisationFinance.ModifiedBy = modifiedBy;
            await _unitOfWork.OrganisationFinanceRepository.UpdateAsync(organisationFinance);
            await _unitOfWork.SaveAsync();
        }
    }
}
