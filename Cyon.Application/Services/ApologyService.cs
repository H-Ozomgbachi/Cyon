using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class ApologyService : IApologyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttendanceTypeService _attendanceTypeService;
        private readonly IMapper _mapper;

        public ApologyService(IUnitOfWork unitOfWork, IAttendanceTypeService attendanceTypeService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _attendanceTypeService = attendanceTypeService;
            _mapper = mapper;
        }

        public async Task<ApologyModel> AddApology(CreateApologyDto apologyDto, Guid userId)
        {
            AttendanceTypeModel attendanceType = await _attendanceTypeService.GetAttendanceType(apologyDto.AttendanceTypeId);

            Apology apology = new()
            {
                For = attendanceType.Name,
                AttendanceTypeId = apologyDto.AttendanceTypeId,
                Date = apologyDto.Date,
                Reason = apologyDto.AbsenteeReason,
                UserId = userId,
                UserEmail = apologyDto.UserEmail,
            };

            await _unitOfWork.ApologyRepository.AddAsync(apology);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ApologyModel>(apology);
        }

        public async Task ApproveApology(ResolveApologyDto apology)
        {
            AttendanceRegister attendanceRegister = new()
            {
                AttendanceTypeId = apology.AttendanceTypeId,
                AttendanceTypeName = apology.For,
                DateAdded = apology.Date,
                UserId = apology.UserId,
                UserEmail = apology.UserEmail,
                IsPresent = true,
                Rating = 3,
            };
            await _unitOfWork.AttendanceRegisterRepository.AddAsync(attendanceRegister);

            Apology apologyToUpdate = _mapper.Map<Apology>(apology);
            apologyToUpdate.IsResolved = true;
            await _unitOfWork.ApologyRepository.UpdateAsync(apologyToUpdate);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeclineApology(ResolveApologyDto apologyDto)
        {
            if (string.IsNullOrWhiteSpace(apologyDto.RejectionReason))
            {
                throw new ConflictException("No rejection reason was provided");
            }
            Apology apologyToUpdate = _mapper.Map<Apology>(apologyDto);
            apologyToUpdate.IsResolved = true;
            apologyToUpdate.IsRejected = true;
            await _unitOfWork.ApologyRepository.UpdateAsync(apologyToUpdate);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteApology(Guid id)
        {
            Apology apology = await _unitOfWork.ApologyRepository.GetByIdAsync(id);

            if (apology == null)
            {
                throw new NotFoundException("Apology no longer exist");
            }

            await _unitOfWork.ApologyRepository.DeleteAsync(apology);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ApologyModel>> GetApologies(Pagination pagination, bool isPending)
        {
            IEnumerable<Expression<Func<Apology, bool>>>? filter = null;

            if (isPending)
            {
                filter = new List<Expression<Func<Apology, bool>>>
                {
                    x => x.IsResolved == false
                };
            }

            IEnumerable<Apology> apologies = await _unitOfWork.ApologyRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);
            return _mapper.Map<IEnumerable<ApologyModel>>(apologies);
        }

        public async Task<IEnumerable<ApologyModel>> GetApologiesByUser(Guid userId, Pagination pagination)
        {
            var filter = new List<Expression<Func<Apology, bool>>>
            {
                x => x.UserId == userId,
                x => x.IsResolved == true
            };

            IEnumerable<Apology> apologies = await _unitOfWork.ApologyRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<ApologyModel>>(apologies);
        }

        public async Task UpdateApology(Apology apology)
        {
            await _unitOfWork.ApologyRepository.UpdateAsync(apology);
            await _unitOfWork.SaveAsync();
        }
    }
}
