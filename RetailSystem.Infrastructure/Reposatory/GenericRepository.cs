﻿using RetailSystem.Domain.Specifications;
using RetailSystem.Infrastructure.Context;
using RetailSystem.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RetailSystem.Infrastructure.Reposatory
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _entity;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }
        public async Task Add(T entity) => await _entity.AddAsync(entity);
        public async Task AddRange(List<T> entities) => await _entity.AddRangeAsync(entities);
        public void Delete(T entity) => _entity.Remove(entity);
        public void DeleteRange(IEnumerable<T> entity) => _entity.RemoveRange(entity);
        public void Update(T entity) => _entity.Update(entity);
        public void UpdateRange(IEnumerable<T> entities) => _entity.UpdateRange(entities);
        public async Task<T?> GetById(long id) => await _entity.FindAsync(id);
        public async Task<T?> GetById(int id) => await _entity.FindAsync(id);
        public async Task<T?> GetById(string id) => await _entity.FindAsync(id);
        public (IQueryable<T> data, int count) GetWithSpec(BaseSpecification<T> specifications) => SpecificationQueryBuilder<T>.GetQuery(_entity, specifications);
        public T? GetEntityWithSpec(BaseSpecification<T> specifications) => SpecificationQueryBuilder<T>.GetQuery(_entity, specifications).data.FirstOrDefault();
        public async Task<bool> IsExist(Expression<Func<T, bool>> filter) => await _entity.AnyAsync(filter);
        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
    }
}