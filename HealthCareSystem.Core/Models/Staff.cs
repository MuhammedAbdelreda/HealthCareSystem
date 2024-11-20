using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        //many-one->Hospital
        public int HospitalId { get; set; }
    }
}