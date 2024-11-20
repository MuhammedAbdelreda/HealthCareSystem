using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Hospital.Dtos
{
    public class CreateUpdateHosiptalDto
    {
        [Required]  // Indicates that this property is required
        [StringLength(100)]  // Limits the length of the Name string to a maximum of 100 characters
        public string Name { get; set; }

        [StringLength(250)]  // Limits the length of the Address string to a maximum of 250 characters
        public string Address { get; set; }  // Optional, but you can add [Required] if necessary
    }
}