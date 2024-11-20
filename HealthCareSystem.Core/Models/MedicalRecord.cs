using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        //one-many->Prescription
        public List<Prescription> Prescriptions { get; set; }
    }
}