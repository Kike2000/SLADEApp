using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Persistences.Context;
using CongresoSlade.Infrastructure.Persistences.Interfaces;

namespace CongresoSlade.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CongresoServerDbContext _context;
        public IEventoRepository Evento { get; private set; }
        public UnitOfWork(CongresoServerDbContext context)
        {
            _context = context;
            Evento = new EventoRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
