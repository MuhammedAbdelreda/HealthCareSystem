using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Staff.Dtos;

namespace HealthCareSystem.Core.IServices.Staff
{
    public interface IStaffService
    {
        Task AddNewStaff(CreateUpdateStaffDto Staff);
        Task UpdateStaff(int id, CreateUpdateStaffDto Staff);
        Task DeleteStaff(int id);
        Task<List<StaffDto>> GetAllStaffs();
        Task<StaffDto> GetStaffById(int id);
    }
}