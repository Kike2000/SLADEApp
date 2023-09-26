using AutoMapper;
using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Validators.Evento;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using CongresoSlade.Utilities.Static;
using FluentValidation;
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
        private readonly EventoValidator _validationRules;

        public EventoApplication(IUnitOfWork unitOfWork, IMapper mapper, EventoValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<EventoResponseDTO>> EventoById(Guid id)
        {
            var response = new BaseResponse<EventoResponseDTO>();
            var category = await _unitOfWork.Evento.GetByIdAsync(id);
            if (category != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<EventoResponseDTO>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditEvento(Guid eventoId, EventoRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await EventoById(eventoId);
            if (categoryEdit.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var evento = _mapper.Map<Evento>(requestDTO);
            evento.Id = eventoId;
            response.Data = await _unitOfWork.Evento.EditAsync(evento);
            if (response.Data)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_FAIL;
            }

            return response;
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

        public async Task<BaseResponse<IEnumerable<EventoSelectResponseDTO>>> ListSelectEventos()
        {
            var response = new BaseResponse<IEnumerable<EventoSelectResponseDTO>>();
            var eventos = await _unitOfWork.Evento.GetAlltAsync();
            if (eventos != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<IEnumerable<EventoSelectResponseDTO>>(eventos);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterEvento(EventoRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(requestDTO);
            if (!validationResult.IsValid)
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
            var category = _mapper.Map<Evento>(requestDTO);
            response.Data = await _unitOfWork.Evento.RegisterAsync(category);
            if (response.Data)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_FAIL;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveEvento(Guid eventoId)
        {
            var response = new BaseResponse<bool>();
            var eventoExists = await EventoById(eventoId);
            if (eventoExists.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Evento.RemoveAsync(eventoId);
            if (response.Data)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_FAIL;
            }

            return response;
        }
    }
}
