using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Doctor.Dtos;

namespace HealthCareSystem.Core.IServices.Doctor
{
    public interface IDoctorService
    {
        Task AddNewDoctor(CreateUpdateDoctorDto Doctor);
        Task BulkAddDoctors(IEnumerable<CreateUpdateDoctorDto> Doctors);
        Task UpdateDoctor(int id, CreateUpdateDoctorDto Doctor);
        Task BulkUpdateDoctors(IEnumerable<int>ids,IEnumerable<CreateUpdateDoctorDto>Doctors);
        Task DeleteDoctor(int id);
        Task<List<DoctorDto>> GetAllDoctors();
        Task<DoctorDto> GetDoctorById(int id);
    }
}