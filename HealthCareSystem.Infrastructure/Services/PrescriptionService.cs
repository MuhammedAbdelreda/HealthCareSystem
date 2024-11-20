using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.Prescription;
using HealthCareSystem.Core.IServices.Prescription.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IGenericRepo<Prescription> Repo;
        private readonly IMapper mapper;

        public PrescriptionService(IGenericRepo<Prescription> repo, IMapper mapper)
        {
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewPrescription(CreateUpdatePrescriptionDto Prescription)
        {
            var result = mapper.Map<CreateUpdatePrescriptionDto, Prescription>(Prescription);
            await Repo.CreateAsync(result);

        }

        public async Task DeletePrescription(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<PrescriptionDto>> GetAllPrescriptions()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<Prescription>, List<PrescriptionDto>>(result);
        }

        public async Task<PrescriptionDto> GetPrescriptionById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                return mapper.Map<Prescription, PrescriptionDto>(result);
            }
            return null;
        }

        public async Task UpdatePrescription(int id, CreateUpdatePrescriptionDto Prescription)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                var resultToUpdate = mapper.Map(Prescription, result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }

}