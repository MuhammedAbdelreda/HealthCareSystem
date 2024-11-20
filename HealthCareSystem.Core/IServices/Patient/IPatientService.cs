using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Patient;
using HealthCareSystem.Core.Specifications;

namespace HealthCareSystem.Core.IServices
{
    public interface IPatientService
    {
        Task AddNewPatient(CreateUpdatePatientDto patient);
        Task UpdatePatient(int id,CreateUpdatePatientDto patient);
        Task DeletePatient(int id);
        Task<List<PatientDto>> GetAllPatients(SpecParams param);
        Task<PatientDto> GetPatientById(int id);
    }
}
#region TODO
/*
AddNewPatient
UpdatePatient
DeletePatient
GetAllPatients
GetPatientById
*/
#endregion