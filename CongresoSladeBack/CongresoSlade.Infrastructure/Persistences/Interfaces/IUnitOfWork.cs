using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaración o matrícula de nuestras interfaes a nivel de repository
        IEventoRepository Evento { get; }
        IParticipanteRepository Participante { get; }
        IAreaRepository Area { get; }
        IRegistroRepository Registro { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
