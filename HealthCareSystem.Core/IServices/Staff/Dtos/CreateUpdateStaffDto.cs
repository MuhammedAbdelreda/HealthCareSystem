using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Staff.Dtos
{
    public class CreateUpdateStaffDto
    {
        [Required]  // Indicates that this property is required
        [StringLength(100)]  // Limits the length of the Name string to a maximum of 100 characters
        public string Name { get; set; }

        [Required]  // Indicates that this property is required
        [StringLength(50)]  // Limits the length of the Role string to a maximum of 50 characters
        public string Role { get; set; }
        [Required]
        public int HospitalId { get; set; }
    }
}