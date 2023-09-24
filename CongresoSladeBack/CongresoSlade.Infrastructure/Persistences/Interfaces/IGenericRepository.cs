﻿using CongresoSlade.Infrastructure.Commons.Bases.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAlltAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(int id);
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
    }
}
