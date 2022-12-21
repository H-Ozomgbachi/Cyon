using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Department;
using Cyon.Domain.Models.Department;

namespace Cyon.Domain.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentModel> CreateDepartmentAsync(DepartmentCreateDto department);
        Task UpdateDepartmentAsync(DepartmentUpdateDto department);
        Task DeleteDepartmentAsync(Guid departmentId);
        Task<DepartmentModel> GetDepartmentByIdAsync(Guid departmentId);
        Task<IEnumerable<DepartmentModel>> GetDepartments(Pagination pagination);
    }
}
