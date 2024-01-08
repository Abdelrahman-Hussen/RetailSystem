﻿using RetailSystem.Domain.Specifications;
using System.Linq.Expressions;

namespace RetailSystem.Infrastructure.Reposatory
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task Add(T entity);
        Task AddRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
        Task <T?> GetById(string id);
        Task<T?> GetById(long id);
        Task<T?> GetById(int id);
        T? GetEntityWithSpec(BaseSpecification<T> specifications);
        (IQueryable<T> data, int count) GetWithSpec(BaseSpecification<T> specifications);
        Task<bool> IsExist(Expression<Func<T, bool>> filter);
        Task<bool> Save();
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}