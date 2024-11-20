using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.MedicalRecord.Dtos
{
    public class CreateUpdateMedicalRecordDto
    {
        [Required]  // Indicates that this property is required
        [StringLength(100)]  // Limits the length of the Diagnosis string to a maximum of 100 characters
        public string Diagnosis { get; set; }

        [StringLength(500)]  // Limits the length of the Notes string to a maximum of 500 characters
        public string Notes { get; set; }  // Optional, but you can add [Required] if necessary
    }
}