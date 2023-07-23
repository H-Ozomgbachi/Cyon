using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.DTOs.Games;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Games;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class GamesService : IGamesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GamesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ClearTreasureHuntResults()
        {
            var results = await _unitOfWork.GamesRepository.GetAllAsync();
            _unitOfWork.GamesRepository.DeleteRange(results);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TreasureHuntResultModel>> GetTreasureHuntResults()
        {
            var results = await _unitOfWork.GamesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TreasureHuntResultModel>>(results.OrderBy(x => x.DateAdded));
        }

        public async Task PostTreasureHuntResult(CreateTreasureHuntResultDto createTreasureHuntResult)
        {
            if (await _unitOfWork.GamesRepository.ExistAsync(x => x.FounderName == createTreasureHuntResult.FounderName))
            {
                throw new BadRequestException("Your discovery time is already recorded!");
            }
            TreasureHuntResult treasureHuntResult = _mapper.Map<TreasureHuntResult>(createTreasureHuntResult);
            await _unitOfWork.GamesRepository.AddAsync(treasureHuntResult);
            await _unitOfWork.SaveAsync();
        }
    }
}
