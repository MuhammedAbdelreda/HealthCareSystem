using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.MedicalRecord.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Core.IServices.MedicalRecord
{
    public interface IMedicalRecordService
    {
        Task AddNewMedicalRecord(CreateUpdateMedicalRecordDto MedicalRecord);
        Task UpdateMedicalRecord(int id, CreateUpdateMedicalRecordDto MedicalRecord);
        Task DeleteMedicalRecord(int id);
        Task<List<MedicalRecordDto>> GetAllMedicalRecords();
        Task<MedicalRecordDto> GetMedicalRecordById(int id);
    }
}