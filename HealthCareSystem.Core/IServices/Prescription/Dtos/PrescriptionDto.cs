using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Prescription.Dtos
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public DateTime DatePrescribed { get; set; }
    }
}