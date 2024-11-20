using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.MedicalRecord;
using HealthCareSystem.Core.IServices.MedicalRecord.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class MedicalRecordService:IMedicalRecordService
    {
        private readonly IGenericRepo<MedicalRecord> Repo;
        private readonly IMapper mapper;

        public MedicalRecordService(IGenericRepo<MedicalRecord> repo, IMapper mapper)
        {
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewMedicalRecord(CreateUpdateMedicalRecordDto MedicalRecord)
        {
            var result = mapper.Map<CreateUpdateMedicalRecordDto, MedicalRecord>(MedicalRecord);
            await Repo.CreateAsync(result);

        }

        public async Task DeleteMedicalRecord(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<MedicalRecordDto>> GetAllMedicalRecords()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<MedicalRecord>, List<MedicalRecordDto>>(result);
        }

        public async Task<MedicalRecordDto> GetMedicalRecordById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                return mapper.Map<MedicalRecord, MedicalRecordDto>(result);
            }
            return null;
        }

        public async Task UpdateMedicalRecord(int id, CreateUpdateMedicalRecordDto MedicalRecord)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                var resultToUpdate = mapper.Map(MedicalRecord, result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}