using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.Hospital;
using HealthCareSystem.Core.IServices.Hospital.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IGenericRepo<Hospital> Repo;
        private readonly IMapper mapper;

        public HospitalService(IGenericRepo<Hospital> repo, IMapper mapper)
        {
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewHospital(CreateUpdateHosiptalDto Hospital)
        {
            var result = mapper.Map<CreateUpdateHosiptalDto, Hospital>(Hospital);
            await Repo.CreateAsync(result);

        }

        public async Task DeleteHospital(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<HospitalDto>> GetAllHospitals()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<Hospital>, List<HospitalDto>>(result);
        }

        public async Task<HospitalDto> GetHospitalById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                return mapper.Map<Hospital, HospitalDto>(result);
            }
            return null;
        }

        public async Task UpdateHospital(int id, CreateUpdateHosiptalDto Hospital)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                var resultToUpdate = mapper.Map(Hospital, result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}