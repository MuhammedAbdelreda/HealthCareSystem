using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareSystem.Core.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //one-many->departments,staff
        public List<Department> Departments { get; set; }
        public List<Staff> Staffs { get; set; }

    }
}