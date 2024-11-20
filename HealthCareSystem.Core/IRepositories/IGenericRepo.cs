using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.Specifications;

namespace HealthCareSystem.Core.IRepositories
{
    public interface IGenericRepo<T> where T:class
    {
        public Task CreateAsync(T entity);
        public Task BulkInsertAsync(IEnumerable<T> entities);
        public Task UpdateAsync(T entity);
        public Task BulkUpdateAsync(IEnumerable<T> entities);
        public Task DeleteAsync(T entity);
        public Task<List<T>> GetAllDataAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAllDataSpecification(ISpecification<T> spec);
        // public Task<T> GetWithIdSpecification(ISpecification<T> spec);
    }
}
#region TODO
/*
Create
Update
Delete
GetAll
GetById
*/
#endregion