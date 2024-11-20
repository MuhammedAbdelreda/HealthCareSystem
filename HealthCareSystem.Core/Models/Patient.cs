using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { set; get; }
        public string Email { get; set; }

        //List of Appointments
        public List<Appointment> Appointments { get; set; }
        //MedicalRecord
        public int MedicalRecordId { get; set; }
    }
}