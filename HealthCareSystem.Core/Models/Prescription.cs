using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public DateTime DatePrescribed { get; set; }
        //many-one->MedicalRecord
        public int MedicalRecordId { get; set; }
    }
}