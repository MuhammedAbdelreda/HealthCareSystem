using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Prescription.Dtos
{
    public class CreateUpdatePrescriptionDto
    {
        [Required]
        [StringLength(100)]
        public string Medication { get; set; }

        [Required]
        [StringLength(50)]
        public string Dosage { get; set; }

        [Required]  // DatePrescribed is now required
        [DataType(DataType.Date)]
        public DateTime DatePrescribed { get; set; }
        [Required]
        public int MedicalRecordId { get; set; }
    }
}