using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices;
using HealthCareSystem.Core.IServices.Patient;
using HealthCareSystem.Core.Models;
using HealthCareSystem.Core.Specifications;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic.FileIO;

namespace HealthCareSystem.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepo<Patient> Repo;
        private readonly IMapper mapper;

        public PatientService(IGenericRepo<Patient> repo, IMapper mapper)
        {
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewPatient(CreateUpdatePatientDto patient)
        {
            var result = mapper.Map<CreateUpdatePatientDto, Patient>(patient);
            await Repo.CreateAsync(result);

        }

        public async Task DeletePatient(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                await Repo.DeleteAsync(result);
            }
        }

        #region GetAllPatients Without Specification
        // public async Task<List<PatientDto>> GetAllPatients()
        // {
        //     var result = await Repo.GetAllDataAsync();
        //     return mapper.Map<List<Patient>, List<PatientDto>>(result);
        // }
        #endregion

        #region GetAllPatients With Specification
        public async Task<List<PatientDto>> GetAllPatients(SpecParams param)
        {
            //var result = await Repo.GetAllDataAsync();
            var spec = new PatientSpecification(param);
            var result = await Repo.GetAllDataSpecification(spec);
            return mapper.Map<List<Patient>, List<PatientDto>>(result);
        }
        #endregion

        #region GetWithId Without Specification
        public async Task<PatientDto> GetPatientById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                return mapper.Map<Patient, PatientDto>(result);
            }
            return null;
        }
        #endregion

        #region GetWithId With Specification
        // public async Task<PatientDto> GetPatientById(int id)
        // {
        //     var spec = new PatientSpecification();
        //     var result = await Repo.GetWithIdSpecification(spec);
        //     if (result != null)
        //     {
        //         return mapper.Map<Patient, PatientDto>(result);
        //     }
        //     return null;
        // }
        #endregion

        public async Task UpdatePatient(int id, CreateUpdatePatientDto patient)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null)
            {
                var resultToUpdate = mapper.Map(patient, result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}