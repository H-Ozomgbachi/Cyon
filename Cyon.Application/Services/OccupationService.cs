using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Occupation;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Models.Occupation;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OccupationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OccupationModel> AddOccupation(CreateOccupationDto occupationDto, Guid userId)
        {
            bool doesUserOccupationExist = await _unitOfWork.OccupationRepository.ExistAsync(x => x.UserId == userId);
            if (doesUserOccupationExist)
            {
                throw new BadRequestException("Your occupation already exist, you can only modify");
            }

            if (occupationDto.IsUnemployed)
            {
                occupationDto.JobTitle = string.Empty; occupationDto.Company = string.Empty;
            }
            if (occupationDto.IsStudent)
            {
                occupationDto.IsUnemployed = false; occupationDto.CanDo = string.Empty;
            }

            Occupation occupation = _mapper.Map<Occupation>(occupationDto);
            occupation.UserId = userId;

            await _unitOfWork.OccupationRepository.AddAsync(occupation);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OccupationModel>(occupation);
        }

        public async Task<OccupationModel> GetOccupationByUser(Guid userId)
        {
            Occupation occupation = await _unitOfWork.OccupationRepository.GetOccupationByUserId(userId);

            return _mapper.Map<OccupationModel>(occupation);
        }

        public async Task<IEnumerable<OccupationModel>> GetOccupations(Pagination pagination)
        {
            IEnumerable<Occupation> occupations = await _unitOfWork.OccupationRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<OccupationModel>>(occupations);
        }

        public async Task<IEnumerable<AccountModelConcise>> PeopleWithSimilarOccupation(string jobKeyWord, Pagination pagination, Guid currentUser)
        {

            var results = await _unitOfWork.OccupationRepository.PeopleWithSimilarOccupation(jobKeyWord, pagination, currentUser);

            return results.Select(x => new AccountModelConcise()
            {
                Id = Guid.Parse(x.User.Id),
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                PhoneNumber = x.User.PhoneNumber,
                PhotoUrl = x.User.PhotoUrl,
            });
        }

        public async Task UpdateOccupation(UpdateOccupationDto occupationDto)
        {
            Occupation occupation = await _unitOfWork.OccupationRepository.GetByIdAsync(occupationDto.Id);

            if (occupation == null)
            {
                throw new NotFoundException("Occupation does not exist");
            }
            if (occupationDto.IsUnemployed)
            {
                occupationDto.JobTitle = string.Empty; occupationDto.Company = string.Empty;
            }
            if (occupationDto.IsStudent)
            {
                occupationDto.IsUnemployed = false; occupationDto.CanDo = string.Empty;
            }
            _mapper.Map(occupationDto, occupation);
            await _unitOfWork.OccupationRepository.UpdateAsync(occupation);
            await _unitOfWork.SaveAsync();
        }
    }
}
