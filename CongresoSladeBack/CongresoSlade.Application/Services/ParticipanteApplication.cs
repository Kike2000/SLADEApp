using AutoMapper;
using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Validators.Participante;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using CongresoSlade.Utilities.Static;
using FluentValidation;

namespace CongresoSlade.Application.Services
{
    public class ParticipanteApplication : IParticipanteApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ParticipanteValidator _validationRules;

        public ParticipanteApplication(IUnitOfWork unitOfWork, IMapper mapper, ParticipanteValidator participanteValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = participanteValidator;
        }

        public async Task<BaseResponse<bool>> EditParticipante(Guid participanteId, ParticipanteRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var participanteEdit = await ParticipanteById(participanteId);
            if (participanteEdit.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var participante = _mapper.Map<Participante>(requestDTO);
            participante.Id = participanteId;
            response.Data = await _unitOfWork.Participante.EditAsync(participante);
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

        public async Task<BaseResponse<BaseEntityResponse<ParticipanteResponseDTO>>> ListParticipantes(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ParticipanteResponseDTO>>();
            var participantes = await _unitOfWork.Participante.ListParticipantes(filters);
            if (participantes != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<BaseEntityResponse<ParticipanteResponseDTO>>(participantes);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterParticipante(ParticipanteRequestDTO requestDTO)
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
            var participante = _mapper.Map<Participante>(requestDTO);
            participante.Id = Guid.NewGuid();
            response.Data = await _unitOfWork.Participante.RegisterAsync(participante);
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
        public async Task<BaseResponse<IEnumerable<ParticipanteSelectResponseDTO>>> ListSelectParticipantes()
        {
            var response = new BaseResponse<IEnumerable<ParticipanteSelectResponseDTO>>();
            var participantes = await _unitOfWork.Participante.GetAlltAsync();
            if (participantes != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<IEnumerable<ParticipanteSelectResponseDTO>>(participantes);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<ParticipanteResponseDTO>> ParticipanteById(Guid id)
        {
            var response = new BaseResponse<ParticipanteResponseDTO>();
            var participante = await _unitOfWork.Participante.GetByIdAsync(id);
            if (participante != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<ParticipanteResponseDTO>(participante);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveParticipante(Guid participanteId)
        {
            var response = new BaseResponse<bool>();
            var participanteExist = await ParticipanteById(participanteId);
            if (participanteExist.Data == null)
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }
            response.Data = await _unitOfWork.Participante.RemoveAsync(participanteId);
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
