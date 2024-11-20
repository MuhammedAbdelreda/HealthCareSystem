using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Appointment.Dtos
{
    public class CreateUpdateAppointmentDto
    {

        [Required]  // Indicates that this property is required
        [DataType(DataType.Date)]  // Specifies that the date should be formatted as a date
        public DateTime AppointmentDate { get; set; }

        [Required]  // Indicates that this property is required
        [StringLength(50)]  // Limits the length of the status string to a maximum of 50 characters
        public string Status { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
    }
}