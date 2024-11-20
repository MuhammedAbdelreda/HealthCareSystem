using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.Department;
using HealthCareSystem.Core.IServices.Department.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepo<Department> Repo;
        private readonly IMapper mapper;

        public DepartmentService(IGenericRepo<Department> repo, IMapper mapper)
        {
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewDepartment(CreateUpdateDepartmentDto Department)
        {
            var result = mapper.Map<CreateUpdateDepartmentDto, Department>(Department);
            await Repo.CreateAsync(result);

        }

        public async Task DeleteDepartment(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<Department>, List<DepartmentDto>>(result);
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                return mapper.Map<Department, DepartmentDto>(result);
            }
            return null;
        }

        public async Task UpdateDepartment(int id, CreateUpdateDepartmentDto Department)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                var resultToUpdate = mapper.Map(Department, result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}