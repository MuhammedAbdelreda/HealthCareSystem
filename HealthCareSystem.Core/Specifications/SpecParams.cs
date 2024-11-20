using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace HealthCareSystem.Core.Specifications
{
    public class SpecParams
    {
        public string? Sort { get; set; }
        public int? PatientId { get; set; }
        public string? FilterByFirstName { get; set; }
        public int PageIndex { get; set; }
        public int pageSize = 5;
        private int MaxPageSize = 50;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? 50 : value; }
        }

    }
}