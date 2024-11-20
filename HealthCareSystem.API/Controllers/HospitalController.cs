using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Hospital;
using HealthCareSystem.Core.IServices.Hospital.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HospitalController : Controller
        {
        private readonly IHospitalService service;
        private readonly ILogger<HospitalController> logger;

        public HospitalController(IHospitalService service,ILogger<HospitalController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewHospital")]
        public async Task Create([FromBody]CreateUpdateHosiptalDto Hospital){
            logger.LogInformation("Attempting to create a new Hospital wtih details:{@Hospital}",Hospital);
            try
            {
                await  service.AddNewHospital(Hospital);
                logger.LogInformation("Successfulyy create a new Hospital.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new Hospital.");
                throw;
            }
            
        }

        [HttpPut("UpdateHospital")]
        public async Task Update(int id,[FromBody]CreateUpdateHosiptalDto Hospital){
            logger.LogInformation(@"Attempting to update Hospital with ID {Id} and details: {@Hospital}", id, Hospital);
            try
            {
                await service.UpdateHospital(id,Hospital);
                logger.LogInformation("Successfully updated Hospital with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating Hospital with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemoveHospital")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete Hospital with ID {Id}.", id);
            try
            {
                await service.DeleteHospital(id);
                logger.LogInformation("Successfully deleted Hospital with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting Hospital with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllHospitals")]
        public async Task<List<HospitalDto>> GetALL(){
            logger.LogInformation("Retrieving all Hospitals.");
            try
            {
                //return await service.GetAllHospitals();
                var Hospitals = await service.GetAllHospitals();
                logger.LogInformation("Successfully retrieved {Count} Hospitals.", Hospitals.Count);
                return Hospitals;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all Hospitals.");
                throw;
            }
        }

        [HttpGet("GetHospitalWithId")]
        public async Task<HospitalDto> GetWithId(int id){
            logger.LogInformation("Retrieving Hospital with ID {Id}.", id);
            try
            {
                //return await service.GetHospitalById(id);
                var Hospital = await service.GetHospitalById(id);
                if(Hospital==null){
                    logger.LogWarning("Hospital with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved Hospital with ID {Id}.", id);
                return Hospital;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving Hospital with ID {Id}.", id);
                throw;
            }
        }
    }
}