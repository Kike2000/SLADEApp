using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;

namespace CongresoSlade.Infrastructure.Persistences.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        Task<BaseEntityResponse<Area>> ListAreas(BaseFilterRequest filters);
    }
}
