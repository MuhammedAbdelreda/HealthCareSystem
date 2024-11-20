using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.MedicalRecord;
using HealthCareSystem.Core.IServices.MedicalRecord.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MedicalRecordController : Controller

    {
        private readonly IMedicalRecordService service;
        private readonly ILogger<MedicalRecordController> logger;

        public MedicalRecordController(IMedicalRecordService service,ILogger<MedicalRecordController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewMedicalRecord")]
        public async Task Create([FromBody]CreateUpdateMedicalRecordDto MedicalRecord){
            logger.LogInformation("Attempting to create a new MedicalRecord wtih details:{@MedicalRecord}",MedicalRecord);
            try
            {
                await  service.AddNewMedicalRecord(MedicalRecord);
                logger.LogInformation("Successfulyy create a new MedicalRecord.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new MedicalRecord.");
                throw;
            }
            
        }

        [HttpPut("UpdateMedicalRecord")]
        public async Task Update(int id,[FromBody]CreateUpdateMedicalRecordDto MedicalRecord){
            logger.LogInformation(@"Attempting to update MedicalRecord with ID {Id} and details: {@MedicalRecord}", id, MedicalRecord);
            try
            {
                await service.UpdateMedicalRecord(id,MedicalRecord);
                logger.LogInformation("Successfully updated MedicalRecord with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating MedicalRecord with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemoveMedicalRecord")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete MedicalRecord with ID {Id}.", id);
            try
            {
                await service.DeleteMedicalRecord(id);
                logger.LogInformation("Successfully deleted MedicalRecord with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting MedicalRecord with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllMedicalRecords")]
        public async Task<List<MedicalRecordDto>> GetALL(){
            logger.LogInformation("Retrieving all MedicalRecords.");
            try
            {
                //return await service.GetAllMedicalRecords();
                var MedicalRecords = await service.GetAllMedicalRecords();
                logger.LogInformation("Successfully retrieved {Count} MedicalRecords.", MedicalRecords.Count);
                return MedicalRecords;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all MedicalRecords.");
                throw;
            }
        }

        [HttpGet("GetMedicalRecordWithId")]
        public async Task<MedicalRecordDto> GetWithId(int id){
            logger.LogInformation("Retrieving MedicalRecord with ID {Id}.", id);
            try
            {
                //return await service.GetMedicalRecordById(id);
                var MedicalRecord = await service.GetMedicalRecordById(id);
                if(MedicalRecord==null){
                    logger.LogWarning("MedicalRecord with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved MedicalRecord with ID {Id}.", id);
                return MedicalRecord;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving MedicalRecord with ID {Id}.", id);
                throw;
            }
        }
    }
}