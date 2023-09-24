using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Interfaces
{
    public interface IEventoApplication
    {

        Task<BaseResponse<BaseEntityResponse<EventoResponseDTO>>> ListEventos(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<EventoSelectResponseDTO>>> ListSelectEventos();
        Task<BaseResponse<EventoResponseDTO>> EventoById(Guid id);
        Task<BaseResponse<bool>> RegisterEvento(EventoRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditEvento(Guid eventoId, EventoRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveEvento(Guid eventoId);
    }
}
