using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Helpers;
using CongresoSlade.Infrastructure.Persistences.Context;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace CongresoSlade.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CongresoServerDbContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(CongresoServerDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<bool> RegisterAsync(T entity)
        {
            await _context.AddAsync(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
        public async Task<bool> EditAsync(T entity)
        {
            _context.Update(entity);

            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<IEnumerable<T>> GetAlltAsync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }
        public async Task<IEnumerable<T>> GetAllParticipantestAsync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter != null) { query = query.Where(filter); }
            return query;
        }


        public async Task<bool> RemoveAsync(Guid id)
        {
            var entity = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);

            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDTO = paginationRequest.Order == "desc" ? queryable.OrderBy($"{paginationRequest.Sort} descending") : queryable.OrderBy($"{paginationRequest.Sort} ascending");
            if (pagination)
                queryDTO = queryDTO.Paginate(paginationRequest);
            return queryDTO;
        }

        //IQueryable<TDTO> IGenericRepository<T>.Ordering<TDTO>(BasePaginationRequest paginationRequest, IQueryable<TDTO> queryable, bool pagination)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<T> GetByIdAsync(Guid id)
        {
            var getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return getById!;
        }

        public async Task<bool> RegisterUserAsync(T entity)
        {
            var user = new AspNetUser { Password = entity.Password, Id = entity.Id };
            //var result = await _userManager.CreateAsync(user, entity.Password);
            //if (result.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(user, entity.Role);
            //    return true;
            //}
            return false;
        }
    }
}