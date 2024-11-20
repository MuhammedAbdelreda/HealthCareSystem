using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Department.Dtos
{
    public class CreateUpdateDepartmentDto
    {
        [Required]  // Indicates that this property is required
        [StringLength(100)]  // Limits the length of the Name string to a maximum of 100 characters
        public string Name { get; set; }
        [Required]
        public int HospitalId { get; set; }
    }
}