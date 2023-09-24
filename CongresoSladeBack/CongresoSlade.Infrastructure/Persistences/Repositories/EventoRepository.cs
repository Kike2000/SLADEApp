using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using CongresoSlade.Infrastructure.Persistences.Context;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Infrastructure.Persistences.Repositories
{
    public class EventoRepository : GenericRepository<Evento>, IEventoRepository
    {
        public EventoRepository(CongresoServerDbContext context) : base(context) { }
        public async Task<BaseEntityResponse<Evento>> ListEventos(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Evento>();
            var events = GetEntityQuery(x => x.AgendaAbierta);

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        events = events.Where(p => p.Nombre == filters.TextFilter);
                        break;
                }
            }
            if (filters.StateFilter is not null)
            {
                events = events.Where(x => x.AgendaAbierta.Equals(filters.StateFilter));
            }

            if (filters.StartDate is not null && filters.EndDate is not null)
            {
                events = events.Where(x => x.HoraInicio >= Convert.ToDateTime(filters.StartDate) && x.HoraTermino <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";
            response.TotalRecords = await events.CountAsync();
            response.Items = await Ordering(filters, events, !(bool)filters.Download!).ToListAsync();
            // ?? es llamado null-coalescing operator es usado cuando un valor es nulo
            //response.Items = await Ordering(filters, categories, filters.Download ?? false).ToListAsync();

            return response;
        }
    }
}
