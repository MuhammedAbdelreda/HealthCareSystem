using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace HealthCareSystem.Infrastructure.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly Context context;

        public GenericRepo(Context context){
            this.context = context;
        }

        public async Task BulkInsertAsync(IEnumerable<T> entities)
        {
            await context.BulkInsertAsync(entities.ToList());
            await context.SaveChangesAsync();
        }

        public async Task BulkUpdateAsync(IEnumerable<T> entities)
        {
            await context.BulkUpdateAsync(entities.ToList());
            await context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllDataAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllDataSpecification(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        // public async Task<T> GetWithIdSpecification(ISpecification<T> spec)
        // {
        //     return await ApplySpecifications(spec).FirstOrDefaultAsync();

        // }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecification<T> spec){
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(),spec);
        }
    }
}