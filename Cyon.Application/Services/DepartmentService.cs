using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Department;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Department;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentModel> CreateDepartmentAsync(DepartmentCreateDto department)
        {
            Department dept = _mapper.Map<Department>(department);

            await _unitOfWork.DepartmentRepository.AddAsync(dept);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<DepartmentModel>(dept);
        }

        public async Task DeleteDepartmentAsync(Guid departmentId)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);

            if (department == null)
            {
                throw new NotFoundException("Department not found");
            }
            await _unitOfWork.DepartmentRepository.DeleteAsync(department);
            await _unitOfWork.SaveAsync();
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(Guid departmentId)
        {
            Department department = await _unitOfWork.DepartmentRepository.GetByIdAsync(departmentId);
            if (department == null)
            {
                throw new NotFoundException("Department not found");
            }
            return _mapper.Map<DepartmentModel>(department);
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartments(Pagination pagination)
        {
            IEnumerable<Department> departments = await _unitOfWork.DepartmentRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<DepartmentModel>>(departments);
        }

        public async Task UpdateDepartmentAsync(DepartmentUpdateDto department)
        {
            Department dept = await _unitOfWork.DepartmentRepository.GetByIdAsync(department.Id);

            if (dept == null)
            {
                throw new NotFoundException("Department not found");
            }

            _mapper.Map(department, dept);
            await _unitOfWork.DepartmentRepository.UpdateAsync(dept);
            await _unitOfWork.SaveAsync();
        }
    }
}
