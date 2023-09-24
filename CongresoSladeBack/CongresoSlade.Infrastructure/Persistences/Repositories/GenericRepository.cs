using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Helpers;
using CongresoSlade.Infrastructure.Persistences.Context;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CongresoSlade.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CongresoServerDbContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(CongresoServerDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public Task<bool> RegisterAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAlltAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter != null) { query = query.Where(filter); }
            return query;
        }


        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDTO = paginationRequest.Order == "desc" ? queryable.OrderBy($"{paginationRequest.Sort} descending") : queryable.OrderBy($"{paginationRequest.Sort} ascending");
            if (pagination)
                queryDTO = queryDTO.Paginate(paginationRequest);
            return queryDTO;
        }

        IQueryable<TDTO> IGenericRepository<T>.Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination)
        {
            throw new NotImplementedException();
        }
    }
}
