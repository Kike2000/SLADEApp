using AutoMapper;
using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using CongresoSlade.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Services
{
    public class EventoApplication : IEventoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly CategoryValidator _validationRules;

        public EventoApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<EventoResponseDTO>> EventoById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditEvento(Guid eventoId, EventoRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<BaseEntityResponse<EventoResponseDTO>>> ListEventos(BaseFilterRequest filters)
        {

            var response = new BaseResponse<BaseEntityResponse<EventoResponseDTO>>();
            var eventos = await _unitOfWork.Evento.ListEventos(filters);
            if (eventos != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<BaseEntityResponse<EventoResponseDTO>>(eventos);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public Task<BaseResponse<IEnumerable<EventoSelectResponseDTO>>> ListSelectEventos()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RegisterEvento(EventoRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RemoveEvento(Guid eventoId)
        {
            throw new NotImplementedException();
        }
    }
}
