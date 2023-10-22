using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using CongresoSlade.Infrastructure.Persistences.Context;
using CongresoSlade.Infrastructure.Persistences.Interfaces;

namespace CongresoSlade.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<AspNetUser>, IUserRepository
    {
        public UserRepository(CongresoServerDbContext context) : base(context)
        {
        }
        public async Task<BaseEntityResponse<AspNetUser>> ListUsers(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<AspNetUser>();
            //var areas = GetEntityQuery(x => x.Nombre != null);

            //if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            //{
            //    switch (filters.NumFilter)
            //    {
            //        case 1:
            //            areas = areas.Where(p => p.Nombre == filters.TextFilter);
            //            break;
            //    }
            //}
            ////if (filters.StateFilter is not null)
            ////{
            ////    participantes = participantes.Where(x => x.AgendaAbierta.Equals(filters.StateFilter));
            ////}

            //if (filters.Sort is null) filters.Sort = "Id";
            //response.TotalRecords = await areas.CountAsync();
            //response.Items = await Ordering(filters, areas, !(bool)filters.Download!).ToListAsync();
            // ?? es llamado null-coalescing operator es usado cuando un valor es nulo
            //response.Items = await Ordering(filters, categories, filters.Download ?? false).ToListAsync();

            return response;
        }
    }
}
