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
    public class DecisionResponseService : IDecisionResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DecisionResponseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DecisionResponseModel> AddDecisionResponse(CreateDecisionResponseDto decisionResponseDto, string userCode)
        {
            if ((await _unitOfWork.DecisionResponseRepository.ExistAsync(x => x.DecisionId == decisionResponseDto.DecisionId && x.CreatedBy == userCode)))
            {
                throw new BadRequestException("Already provided response");
            }

            DecisionResponse decisionResponse = _mapper.Map<DecisionResponse>(decisionResponseDto);
            decisionResponse.CreatedBy = userCode;

            await _unitOfWork.DecisionResponseRepository.AddAsync(decisionResponse);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<DecisionResponseModel>(decisionResponse);
        }

        public async Task<IEnumerable<DecisionResponseModel>> GetDecisionResponses(Guid decisionId, Pagination pagination)
        {
            var filter = new List<Expression<Func<DecisionResponse, bool>>>
            {
                f => f.DecisionId == decisionId,
            };

            IEnumerable<DecisionResponse> decisionResponses = await _unitOfWork.DecisionResponseRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<DecisionResponseModel>>(decisionResponses);
        }

        public async Task<DecisionResponseModel> GetMyDecisionResponse(Guid decisionId, string userCode)
        {
            var filter = new List<Expression<Func<DecisionResponse, bool>>>
            {
                f => f.DecisionId == decisionId,
                f => f.CreatedBy == userCode
            };
            var decisionResponseThatMatch = await _unitOfWork.DecisionResponseRepository.GetFirstMatchAsync(filter, null);

            if (decisionResponseThatMatch == null)
            {
                throw new NotFoundException("You did not provide a response for this decision");
            }

            return _mapper.Map<DecisionResponseModel>(decisionResponseThatMatch);
        }
    }
}
