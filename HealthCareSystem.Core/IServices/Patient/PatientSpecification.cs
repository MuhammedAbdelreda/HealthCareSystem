using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.Models;
using HealthCareSystem.Core.Specifications;
using Microsoft.AspNetCore.Identity;

namespace HealthCareSystem.Core.IServices.Patient
{
    public class PatientSpecification : BaseSpecification<Models.Patient>
    {
        public PatientSpecification()
        {
            //AddInclude(p => p.Id);
            //AddInclude(p => p.FirstName);
        }
        public PatientSpecification(SpecParams param)
        :base(p=>
        (!param.PatientId.HasValue || p.Id == param.PatientId)
        &&(string.IsNullOrWhiteSpace(param.FilterByFirstName) ||p.FirstName.Contains(param.FilterByFirstName))
        )
        {
            //AddInclude(p => p.Id);
            //AddInclude(p => p.FirstName);
            AddOrderBy(p => p.Id);
            if (param.pageSize > 0 && param.PageIndex > 0)
            {
                ApplyPagination(param.PageSize * (param.PageIndex - 1), param.pageSize);
            }

            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "asc":
                        AddOrderBy(p => p.FirstName);
                        break;
                    case "des":
                        AddOrderByDes(p => p.FirstName);
                        break;
                    default:
                        AddOrderBy(p => p.Id);
                        break;
                }
            }
        }
    }
}