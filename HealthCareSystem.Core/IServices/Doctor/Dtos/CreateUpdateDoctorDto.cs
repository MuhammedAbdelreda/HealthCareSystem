using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.IServices.Doctor.Dtos
{
    public class CreateUpdateDoctorDto
    {

    [Required]  // Indicates that this property is required
    [StringLength(50)]  // Limits the length of the FirstName string to a maximum of 50 characters
    public string FirstName { get; set; }

    [Required]  // Indicates that this property is required
    [StringLength(50)]  // Limits the length of the LastName string to a maximum of 50 characters
    public string LastName { get; set; }

    [StringLength(100)]  // Limits the length of the specialty string to a maximum of 100 characters
    public string Specialty { get; set; }  // Use PascalCase for property names
    [Required]
    public int DepartmentId { get; set; }
}
}