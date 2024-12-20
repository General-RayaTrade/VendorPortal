﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.EF.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T? Get(int Id);
        T? Get(Guid Id);
        IEnumerable<T> GetAll();
        ValueTask<IEnumerable<T>> GetAllAsync();
        Task<List<T>> FindAllAsync(
   Expression<Func<T, bool>> expression,
   string[]? includes = null);
        ValueTask<T?> FindAsync(Expression<Func<T, bool>> expression, string[]? includes = null);
        IEnumerable<T?> FindAll(Expression<Func<T, bool>>? expression, string[]? includes = null);
        Task<IEnumerable<T?>> FindAllAsync(Expression<Func<T, bool>> expression,
            int? skip, int? take, Expression<Func<T, object>>? orderBy = null, string? orderByDirection = "ASC");
        IEnumerable<T?> FindAll(Expression<Func<T, bool>> expression,
            int? skip, int? take, Expression<Func<T, object>>? orderBy = null, string? orderByDirection = "ASC");
        T? Add(T entity);
        Task<T?> AddAsync(T entity);
        IEnumerable<T?> AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        T Update(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
