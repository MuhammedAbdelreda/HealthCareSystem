using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Doctor;
using HealthCareSystem.Core.IServices.Doctor.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class DoctorController : Controller
        {
        private readonly IDoctorService service;
        private readonly ILogger<DoctorController> logger;

        public DoctorController(IDoctorService service,ILogger<DoctorController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewDoctor")]
        public async Task Create([FromBody]CreateUpdateDoctorDto Doctor){
            logger.LogInformation("Attempting to create a new Doctor wtih details:{@Doctor}",Doctor);
            try
            {
                await  service.AddNewDoctor(Doctor);
                logger.LogInformation("Successfulyy create a new Doctor.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new Doctor.");
                throw;
            }
            
        }

        [HttpPost("BulkInsertion")]
        public async  Task BulkInsertion([FromBody]IEnumerable<CreateUpdateDoctorDto> Doctors){
            logger.LogInformation("Attempting to bulk insert Doctors with details:{@Doctors}",Doctors);
            try
            {
                await service.BulkAddDoctors(Doctors);
                logger.LogInformation("Successfully  bulk inserted Doctors.");

            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occured while adding  Doctors.");

                throw;
            }
        }


        [HttpPut("UpdateDoctor")]
        public async Task Update(int id,[FromBody]CreateUpdateDoctorDto Doctor){
            logger.LogInformation(@"Attempting to update Doctor with ID {Id} and details: {@Doctor}", id, Doctor);
            try
            {
                await service.UpdateDoctor(id,Doctor);
                logger.LogInformation("Successfully updated Doctor with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating Doctor with ID {Id}.", id);
                throw;
            }
        }

        [HttpPut("BulkUpdate")]
        public async Task  BulkUpdate([FromRoute]IEnumerable<int> ids,[FromBody]IEnumerable<CreateUpdateDoctorDto> Doctors){
            logger.LogInformation("Attempting to bulk update Doctors with details:{@Doctors}",Doctors);
            try
            {
                await service.BulkUpdateDoctors(ids,Doctors);
                logger.LogInformation("Successfully bulk updated Doctors.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while updating Doctors.");
                throw;
            }
        }


        [HttpDelete("RemoveDoctor")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete Doctor with ID {Id}.", id);
            try
            {
                await service.DeleteDoctor(id);
                logger.LogInformation("Successfully deleted Doctor with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting Doctor with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllDoctors")]
        public async Task<List<DoctorDto>> GetALL(){
            logger.LogInformation("Retrieving all Doctors.");
            try
            {
                //return await service.GetAllDoctors();
                var Doctors = await service.GetAllDoctors();
                logger.LogInformation("Successfully retrieved {Count} Doctors.", Doctors.Count);
                return Doctors;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all Doctors.");
                throw;
            }
        }

        [HttpGet("GetDoctorWithId")]
        public async Task<DoctorDto> GetWithId(int id){
            logger.LogInformation("Retrieving Doctor with ID {Id}.", id);
            try
            {
                //return await service.GetDoctorById(id);
                var Doctor = await service.GetDoctorById(id);
                if(Doctor==null){
                    logger.LogWarning("Doctor with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved Doctor with ID {Id}.", id);
                return Doctor;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving Doctor with ID {Id}.", id);
                throw;
            }
        }
    }
}