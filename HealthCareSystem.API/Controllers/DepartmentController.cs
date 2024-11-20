using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Department;
using HealthCareSystem.Core.IServices.Department.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthCareSystem.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class DepartmentController : Controller
        {
        private readonly IDepartmentService service;
        private readonly ILogger<DepartmentController> logger;

        public DepartmentController(IDepartmentService service,ILogger<DepartmentController> _logger){
            this.service = service;
            this.logger = _logger;
        }

        [HttpPost("AddNewDepartment")]
        public async Task Create([FromBody]CreateUpdateDepartmentDto Department){
            logger.LogInformation("Attempting to create a new Department wtih details:{@Department}",Department);
            try
            {
                await  service.AddNewDepartment(Department);
                logger.LogInformation("Successfulyy create a new Department.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"An Error occurred while creating a new Department.");
                throw;
            }
            
        }

        [HttpPut("UpdateDepartment")]
        public async Task Update(int id,[FromBody]CreateUpdateDepartmentDto Department){
            logger.LogInformation(@"Attempting to update Department with ID {Id} and details: {@Department}", id, Department);
            try
            {
                await service.UpdateDepartment(id,Department);
                logger.LogInformation("Successfully updated Department with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating Department with ID {Id}.", id);
                throw;
            }
        }

        [HttpDelete("RemoveDepartment")]
        public async Task Delete(int id){
            logger.LogInformation("Attempting to delete Department with ID {Id}.", id);
            try
            {
                await service.DeleteDepartment(id);
                logger.LogInformation("Successfully deleted Department with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while deleting Department with ID {Id}.", id);
                throw;
            }
        }
        [HttpGet("GetAllDepartments")]
        public async Task<List<DepartmentDto>> GetALL(){
            logger.LogInformation("Retrieving all Departments.");
            try
            {
                //return await service.GetAllDepartments();
                var Departments = await service.GetAllDepartments();
                logger.LogInformation("Successfully retrieved {Count} Departments.", Departments.Count);
                return Departments;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving all Departments.");
                throw;
            }
        }

        [HttpGet("GetDepartmentWithId")]
        public async Task<DepartmentDto> GetWithId(int id){
            logger.LogInformation("Retrieving Department with ID {Id}.", id);
            try
            {
                //return await service.GetDepartmentById(id);
                var Department = await service.GetDepartmentById(id);
                if(Department==null){
                    logger.LogWarning("Department with ID {Id} not found.", id);
                    return null;
                }
                logger.LogInformation("Successfully retrieved Department with ID {Id}.", id);
                return Department;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving Department with ID {Id}.", id);
                throw;
            }
        }
    }
}