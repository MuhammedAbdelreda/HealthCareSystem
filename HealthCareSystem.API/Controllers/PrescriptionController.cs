using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Prescription;
using HealthCareSystem.Core.IServices.Prescription.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PrescriptionController : Controller

    {
        private readonly IPrescriptionService service;
        private readonly ILogger<PrescriptionController> logger;

        public PrescriptionController(IPrescriptionService service,ILogger<PrescriptionController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewPrescription")]
        public async Task Create([FromBody]CreateUpdatePrescriptionDto Prescription){
            logger.LogInformation("Attempting to create a new Prescription wtih details:{@Prescription}",Prescription);
            try
            {
                await  service.AddNewPrescription(Prescription);
                logger.LogInformation("Successfulyy create a new Prescription.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new Prescription.");
                throw;
            }
            
        }

        [HttpPut("UpdatePrescription")]
        public async Task Update(int id,[FromBody]CreateUpdatePrescriptionDto Prescription){
            logger.LogInformation(@"Attempting to update Prescription with ID {Id} and details: {@Prescription}", id, Prescription);
            try
            {
                await service.UpdatePrescription(id,Prescription);
                logger.LogInformation("Successfully updated Prescription with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating Prescription with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemovePrescription")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete Prescription with ID {Id}.", id);
            try
            {
                await service.DeletePrescription(id);
                logger.LogInformation("Successfully deleted Prescription with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting Prescription with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllPrescriptions")]
        public async Task<List<PrescriptionDto>> GetALL(){
            logger.LogInformation("Retrieving all Prescriptions.");
            try
            {
                //return await service.GetAllPrescriptions();
                var Prescriptions = await service.GetAllPrescriptions();
                logger.LogInformation("Successfully retrieved {Count} Prescriptions.", Prescriptions.Count);
                return Prescriptions;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all Prescriptions.");
                throw;
            }
        }

        [HttpGet("GetPrescriptionWithId")]
        public async Task<PrescriptionDto> GetWithId(int id){
            logger.LogInformation("Retrieving Prescription with ID {Id}.", id);
            try
            {
                //return await service.GetPrescriptionById(id);
                var Prescription = await service.GetPrescriptionById(id);
                if(Prescription==null){
                    logger.LogWarning("Prescription with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved Prescription with ID {Id}.", id);
                return Prescription;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving Prescription with ID {Id}.", id);
                throw;
            }
        }
    }
}