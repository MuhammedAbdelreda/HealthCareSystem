using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.MedicalRecord.Dtos
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
    }
}