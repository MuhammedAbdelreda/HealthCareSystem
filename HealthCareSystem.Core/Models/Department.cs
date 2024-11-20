using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //many-one->hospital
        public int HospitalId { get; set; }
        //one-many->doctors
        public List<Doctor> Doctors { get; set; }
    }
}