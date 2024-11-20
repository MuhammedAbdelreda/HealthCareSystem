using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Hospital.Dtos;

namespace HealthCareSystem.Core.IServices.Hospital
{
    public interface IHospitalService
    {
        Task AddNewHospital(CreateUpdateHosiptalDto Hospital);
        Task UpdateHospital(int id, CreateUpdateHosiptalDto Hospital);
        Task DeleteHospital(int id);
        Task<List<HospitalDto>> GetAllHospitals();
        Task<HospitalDto> GetHospitalById(int id);
    }
}