﻿using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using ImportantEventDataAccess.Abstract;
using ImportantEventDataAccess.EfCore;
using ImportantEventEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportantEventDataAccess.Concrete
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ImportantEventDbContext _dbContext;

        public EfRepository(ImportantEventDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);

        }
    }
}
