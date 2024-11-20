using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.Doctor;
using HealthCareSystem.Core.IServices.Doctor.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly IGenericRepo<Doctor> Repo;
        private readonly IMapper mapper;

        public DoctorService(IGenericRepo<Doctor> repo,IMapper mapper){
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewDoctor(CreateUpdateDoctorDto Doctor)
        {
            var result = mapper.Map<CreateUpdateDoctorDto,Doctor>(Doctor);
            await Repo.CreateAsync(result);

        }

        public async Task BulkAddDoctors(IEnumerable<CreateUpdateDoctorDto> Doctors)
        {
            var result = mapper.Map<IEnumerable<Doctor>>(Doctors);
            await Repo.BulkInsertAsync(result);
        }

        public async Task BulkUpdateDoctors(IEnumerable<int> ids, IEnumerable<CreateUpdateDoctorDto> Doctors)
        {
            var result = mapper.Map<IEnumerable<Doctor>>(Doctors);
            await Repo.BulkUpdateAsync(result);
        }

        public async Task DeleteDoctor(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null){
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<Doctor>,List<DoctorDto>>(result);
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null){
                return  mapper.Map<Doctor,DoctorDto>(result);
            }
            return null;
        }

        public async Task UpdateDoctor(int id, CreateUpdateDoctorDto Doctor)
        {
            var result = await  Repo.GetByIdAsync(id);
            if(result!=null){
                var resultToUpdate = mapper.Map(Doctor,result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}