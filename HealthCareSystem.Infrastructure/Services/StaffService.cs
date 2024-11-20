using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.Staff;
using HealthCareSystem.Core.IServices.Staff.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class StaffService:IStaffService
    {
        private readonly IGenericRepo<Staff> Repo;
        private readonly IMapper mapper;

        public StaffService(IGenericRepo<Staff> repo, IMapper mapper)
        {
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewStaff(CreateUpdateStaffDto Staff)
        {
            var result = mapper.Map<CreateUpdateStaffDto, Staff>(Staff);
            await Repo.CreateAsync(result);

        }

        public async Task DeleteStaff(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<StaffDto>> GetAllStaffs()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<Staff>, List<StaffDto>>(result);
        }

        public async Task<StaffDto> GetStaffById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                return mapper.Map<Staff, StaffDto>(result);
            }
            return null;
        }

        public async Task UpdateStaff(int id, CreateUpdateStaffDto Staff)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                var resultToUpdate = mapper.Map(Staff, result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}