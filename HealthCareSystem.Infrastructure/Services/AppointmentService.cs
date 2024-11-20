using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices.Appointment;
using HealthCareSystem.Core.IServices.Appointment.Dtos;
using HealthCareSystem.Core.Models;

namespace HealthCareSystem.Infrastructure.Services
{
    public class AppointmentService:IAppointmentService
        {
        private readonly IGenericRepo<Appointment> Repo;
        private readonly IMapper mapper;

        public AppointmentService(IGenericRepo<Appointment> repo,IMapper mapper){
            this.Repo = repo;
            this.mapper = mapper;
        }
        public async Task AddNewAppointment(CreateUpdateAppointmentDto appointment)
        {
            var result = mapper.Map<CreateUpdateAppointmentDto,Appointment>(appointment);
            await Repo.CreateAsync(result);

        }

        public async Task DeleteAppointment(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null){
                await Repo.DeleteAsync(result);
            }
        }

        public async Task<List<AppointmentDto>> GetAllAppointments()
        {
            var result = await Repo.GetAllDataAsync();
            return mapper.Map<List<Appointment>,List<AppointmentDto>>(result);
        }

        public async Task<AppointmentDto> GetAppointmentById(int id)
        {
            var result = await Repo.GetByIdAsync(id);
            if (result != null){
                return  mapper.Map<Appointment,AppointmentDto>(result);
            }
            return null;
        }

        public async Task UpdateAppointment(int id, CreateUpdateAppointmentDto appointment)
        {
            var result = await  Repo.GetByIdAsync(id);
            if(result!=null){
                var resultToUpdate = mapper.Map(appointment,result);
                await Repo.UpdateAsync(resultToUpdate);
            }

        }
    }
}