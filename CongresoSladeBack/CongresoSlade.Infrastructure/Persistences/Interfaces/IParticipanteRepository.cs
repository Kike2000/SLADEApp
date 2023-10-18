using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Infrastructure.Persistences.Interfaces
{
    public interface IParticipanteRepository : IGenericRepository<Participante>
    {
        Task<BaseEntityResponse<Participante>> ListParticipantes(BaseFilterRequest filters);
    }
}
