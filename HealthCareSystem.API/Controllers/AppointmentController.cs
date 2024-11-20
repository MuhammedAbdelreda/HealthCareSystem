using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Appointment;
using HealthCareSystem.Core.IServices.Appointment.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AppointmentController : Controller
        {
        private readonly IAppointmentService service;
        private readonly ILogger<AppointmentController> logger;

        public AppointmentController(IAppointmentService service,ILogger<AppointmentController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewAppointment")]
        public async Task Create([FromBody]CreateUpdateAppointmentDto Appointment){
            logger.LogInformation("Attempting to create a new Appointment wtih details:{@Appointment}",Appointment);
            try
            {
                await  service.AddNewAppointment(Appointment);
                logger.LogInformation("Successfulyy create a new Appointment.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new Appointment.");
                throw;
            }
            
        }

        [HttpPut("UpdateAppointment")]
        public async Task Update(int id,[FromBody]CreateUpdateAppointmentDto Appointment){
            logger.LogInformation(@"Attempting to update Appointment with ID {Id} and details: {@Appointment}", id, Appointment);
            try
            {
                await service.UpdateAppointment(id,Appointment);
                logger.LogInformation("Successfully updated Appointment with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating Appointment with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemoveAppointment")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete Appointment with ID {Id}.", id);
            try
            {
                await service.DeleteAppointment(id);
                logger.LogInformation("Successfully deleted Appointment with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting Appointment with ID {Id}.", id);
                throw;
            }
        }

        [HttpGet("GetAllAppointments")]
        public async Task<List<AppointmentDto>> GetALL(){
            logger.LogInformation("Retrieving all Appointments.");
            try
            {
                //return await service.GetAllAppointments();
                var Appointments = await service.GetAllAppointments();
                logger.LogInformation("Successfully retrieved {Count} Appointments.", Appointments.Count);
                return Appointments;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all Appointments.");
                throw;
            }
        }

        [HttpGet("GetAppointmentWithId")]
        public async Task<AppointmentDto> GetWithId(int id){
            logger.LogInformation("Retrieving Appointment with ID {Id}.", id);
            try
            {
                //return await service.GetAppointmentById(id);
                var Appointment = await service.GetAppointmentById(id);
                if(Appointment==null){
                    logger.LogWarning("Appointment with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved Appointment with ID {Id}.", id);
                return Appointment;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving Appointment with ID {Id}.", id);
                throw;
            }
        }
    }
}