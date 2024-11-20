using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Staff;
using HealthCareSystem.Core.IServices.Staff.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class StaffController : Controller
        {
        private readonly IStaffService service;
        private readonly ILogger<StaffController> logger;

        public StaffController(IStaffService service,ILogger<StaffController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewStaff")]
        public async Task Create([FromBody]CreateUpdateStaffDto Staff){
            logger.LogInformation("Attempting to create a new Staff wtih details:{@Staff}",Staff);
            try
            {
                await  service.AddNewStaff(Staff);
                logger.LogInformation("Successfulyy create a new Staff.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new Staff.");
                throw;
            }
            
        }

        [HttpPut("UpdateStaff")]
        public async Task Update(int id,[FromBody]CreateUpdateStaffDto Staff){
            logger.LogInformation(@"Attempting to update Staff with ID {Id} and details: {@Staff}", id, Staff);
            try
            {
                await service.UpdateStaff(id,Staff);
                logger.LogInformation("Successfully updated Staff with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating Staff with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemoveStaff")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete Staff with ID {Id}.", id);
            try
            {
                await service.DeleteStaff(id);
                logger.LogInformation("Successfully deleted Staff with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting Staff with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllStaffs")]
        public async Task<List<StaffDto>> GetALL(){
            logger.LogInformation("Retrieving all Staffs.");
            try
            {
                //return await service.GetAllStaffs();
                var Staffs = await service.GetAllStaffs();
                logger.LogInformation("Successfully retrieved {Count} Staffs.", Staffs.Count);
                return Staffs;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all Staffs.");
                throw;
            }
        }

        [HttpGet("GetStaffWithId")]
        public async Task<StaffDto> GetWithId(int id){
            logger.LogInformation("Retrieving Staff with ID {Id}.", id);
            try
            {
                //return await service.GetStaffById(id);
                var Staff = await service.GetStaffById(id);
                if(Staff==null){
                    logger.LogWarning("Staff with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved Staff with ID {Id}.", id);
                return Staff;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving Staff with ID {Id}.", id);
                throw;
            }
        }
    }
}