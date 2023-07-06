using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Decision;
using Cyon.Domain.Services;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class DecisionService : IDecisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DecisionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DecisionModel> AddDecision(CreateDecisionDto decisionDto, string modifiedBy)
        {
            Decision decision = _mapper.Map<Decision>(decisionDto);
            decision.CreatedBy = modifiedBy;
            decision.Options = string.Join(',', decisionDto.Options);

            await _unitOfWork.DecisionRepository.AddAsync(decision);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<DecisionModel>(decision);
        }

        public async Task DeleteDecision(Guid decisionId)
        {
            Decision decision = await _unitOfWork.DecisionRepository.GetByIdAsync(decisionId);

            if (decision == null)
            {
                throw new NotFoundException("Decision was not found");
            }

            _unitOfWork.DecisionRepository.Delete(decision);
            await _unitOfWork.SaveAsync();
        }

        public async Task<DecisionModel> GetDecision(Guid decisionId)
        {
            Decision decision = await _unitOfWork.DecisionRepository.GetByIdAsync(decisionId);

            if (decision == null)
            {
                throw new NotFoundException("Decision was not found");
            }

            return _mapper.Map<DecisionModel>(decision);
        }

        public async Task<IEnumerable<DecisionModel>> GetDecisions(Pagination pagination)
        {
            var filter = new List<Expression<Func<Decision, bool>>>
            {
                f => f.IsActive == true
            };
            IEnumerable<Decision> decisions = await _unitOfWork.DecisionRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<DecisionModel>>(decisions);
        }

        public async Task UpdateDecision(UpdateDecisionDto decisionDto, string modifiedBy)
        {
            Decision decision = await _unitOfWork.DecisionRepository.GetByIdAsync(decisionDto.Id);

            if (decision == null)
            {
                throw new NotFoundException("Decision was not found");
            }

            Decision updatedDecision = _mapper.Map(decisionDto, decision);
            updatedDecision.Options = string.Join(',', decisionDto.Options);
            updatedDecision.LastModifiedBy = modifiedBy; updatedDecision.DateModified = DateTime.UtcNow;

            if (updatedDecision.IsClosed)
            {
                var filter = new List<Expression<Func<DecisionResponse, bool>>>
                {
                    f => f.DecisionId == updatedDecision.Id,

                };
                var decisionResponses = await _unitOfWork.DecisionResponseRepository.GetAllAsync(filter);

                var responses = decisionResponses.GroupBy(x => x.Response);

                HashSet<DecisionResultModel> results = new();

                foreach (var item in responses)
                {
                    var res = new DecisionResultModel
                    {
                        Response = item.Key,
                        NumberOfVotes = item.Count(),
                        LatestVoteTime = item.Max(x => x.DateAdded)
                    };
                    results.Add(res);
                }
                var winner = results.OrderByDescending(x => x.NumberOfVotes).ThenBy(x => x.LatestVoteTime).First();
                updatedDecision.Result = winner?.Response ?? string.Empty;
            }

            await _unitOfWork.DecisionRepository.UpdateAsync(updatedDecision);
            await _unitOfWork.SaveAsync();
        }
    }
}