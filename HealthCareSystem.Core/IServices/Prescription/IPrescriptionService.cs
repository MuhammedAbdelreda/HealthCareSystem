using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Prescription.Dtos;

namespace HealthCareSystem.Core.IServices.Prescription
{
    public interface IPrescriptionService
    {
        Task AddNewPrescription(CreateUpdatePrescriptionDto Prescription);
        Task UpdatePrescription(int id, CreateUpdatePrescriptionDto Prescription);
        Task DeletePrescription(int id);
        Task<List<PrescriptionDto>> GetAllPrescriptions();
        Task<PrescriptionDto> GetPrescriptionById(int id);
    }
}