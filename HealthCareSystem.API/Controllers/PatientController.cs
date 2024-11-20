using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices;
using HealthCareSystem.Core.IServices.Patient;
using HealthCareSystem.Core.Models;
using HealthCareSystem.Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientService service;
        private readonly ILogger<PatientController> logger;

        public PatientController(IPatientService service,ILogger<PatientController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewPatient")]
        public async Task Create([FromBody]CreateUpdatePatientDto patient){
            logger.LogInformation("Attempting to create a new Patient wtih details:{@Patient}",patient);
            try
            {
                await service.AddNewPatient(patient);
                logger.LogInformation("Successfulyy create a new patient.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new patient.");
                throw;
            }
            
        }

        [HttpPut("UpdatePatient")]
        public async Task Update(int id,[FromBody]CreateUpdatePatientDto patient){
            logger.LogInformation(@"Attempting to update patient with ID {Id} and details: {@Patient}", id, patient);
            try
            {
                await service.UpdatePatient(id,patient);
                logger.LogInformation("Successfully updated patient with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating patient with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemovePatient")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete patient with ID {Id}.", id);
            try
            {
                await service.DeletePatient(id);
                logger.LogInformation("Successfully deleted patient with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting patient with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllPatients")]
        public async Task<List<PatientDto>> GetALL([FromQuery]SpecParams param){
            logger.LogInformation("Retrieving all patients.");
            try
            {
                //return await service.GetAllPatients();
                var patients = await service.GetAllPatients(param);
                logger.LogInformation("Successfully retrieved {Count} patients.", patients.Count);
                return patients;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all patients.");
                throw;
            }
        }

        [HttpGet("GetPatientWithId")]
        public async Task<PatientDto> GetWithId(int id){
            logger.LogInformation("Retrieving patient with ID {Id}.", id);
            try
            {
                //return await service.GetPatientById(id);
                var patient = await service.GetPatientById(id);
                if(patient==null){
                    logger.LogWarning("Patient with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved patient with ID {Id}.", id);
                return patient;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving patient with ID {Id}.", id);
                throw;
            }
        }
    }
}

#region TODO
/*
Create
Update
Delete
GetAll
GetById
*/
#endregion