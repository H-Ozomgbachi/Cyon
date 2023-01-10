﻿using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Occupation;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Models.Occupation;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

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
                throw new ConflictException("Your occupation already exist, you can only modify");
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

            if (occupation == null)
            {
                throw new NotFoundException("Occupation does not exist");
            }

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
            _mapper.Map(occupationDto, occupation);
            await _unitOfWork.OccupationRepository.UpdateAsync(occupation);
            await _unitOfWork.SaveAsync();
        }
    }
}
