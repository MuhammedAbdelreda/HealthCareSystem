using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Department.Dtos;

namespace HealthCareSystem.Core.IServices.Department
{
    public interface IDepartmentService
    {
        Task AddNewDepartment(CreateUpdateDepartmentDto department);
        Task UpdateDepartment(int id, CreateUpdateDepartmentDto department);
        Task DeleteDepartment(int id);
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int id);
    }
}