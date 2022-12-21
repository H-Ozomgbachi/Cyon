using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class AttendanceTypeService : IAttendanceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttendanceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AttendanceTypeModel> AddAttendanceType(CreateAttendanceTypeDto attendanceTypeDto)
        {
            AttendanceType attendanceType = _mapper.Map<AttendanceType>(attendanceTypeDto);

            await _unitOfWork.AttendanceTypeRepository.AddAsync(attendanceType);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<AttendanceTypeModel>(attendanceType);
        }

        public async Task DeleteAttendanceType(Guid attendanceTypeId)
        {
            var attendanceType = await _unitOfWork.AttendanceTypeRepository.GetByIdAsync(attendanceTypeId);

            if (attendanceType == null)
            {
                throw new NotFoundException("Attendance type does not exist");
            }

            await _unitOfWork.AttendanceTypeRepository.DeleteAsync(attendanceType);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AttendanceTypeModel> GetAttendanceType(Guid attendanceTypeId)
        {
            var attendanceType = await _unitOfWork.AttendanceTypeRepository.GetByIdAsync(attendanceTypeId);

            if (attendanceType == null)
            {
                throw new NotFoundException("Attendance type does not exist");
            }

            return _mapper.Map<AttendanceTypeModel>(attendanceType);
        }

        public async Task<IEnumerable<AttendanceTypeModel>> GetAttendanceTypes(Pagination pagination)
        {
            IEnumerable<AttendanceType> attendanceTypes = await _unitOfWork.AttendanceTypeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AttendanceTypeModel>>(attendanceTypes);
        }

        public async Task UpdateAttendanceType(UpdateAttendanceTypeDto attendanceTypeDto)
        {
            AttendanceType attendanceType = await _unitOfWork.AttendanceTypeRepository.GetByIdAsync(attendanceTypeDto.Id);

            if (attendanceType == null)
            {
                throw new NotFoundException("Attendance type does not exist");
            }

            _mapper.Map(attendanceTypeDto, attendanceType);
            await _unitOfWork.AttendanceTypeRepository.UpdateAsync(attendanceType);
            await _unitOfWork.SaveAsync();
        }
    }
}
