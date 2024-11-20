using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IServices.Appointment.Dtos;

namespace HealthCareSystem.Core.IServices.Appointment
{
    public interface IAppointmentService
    {
        Task AddNewAppointment(CreateUpdateAppointmentDto appointment);
        Task UpdateAppointment(int id, CreateUpdateAppointmentDto appointment);
        Task DeleteAppointment(int id);
        Task<List<AppointmentDto>> GetAllAppointments();
        Task<AppointmentDto> GetAppointmentById(int id);
    }
}