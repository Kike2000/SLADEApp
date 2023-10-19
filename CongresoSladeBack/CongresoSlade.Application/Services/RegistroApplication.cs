using AutoMapper;
using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.AreaResponse;
using CongresoSlade.Application.DTOs.Response.RegistroResponse;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Validators.Area;
using CongresoSlade.Application.Validators.Registro;
using CongresoSlade.Domain.Entities;
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
    public class RegistroApplication : IRegistroApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RegistroValidator _validationRules;
        public RegistroApplication(IMapper mapper, IUnitOfWork unitOfWork, RegistroValidator registroValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validationRules = registroValidator;
        }

        public async Task<BaseResponse<bool>> EditRegistro(Guid registroId, RegistroRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var registroEdit = await RegistroById(registroId);
            if (registroEdit.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var registro = _mapper.Map<Registro>(requestDTO);
            registro.Id = registroId;
            response.Data = await _unitOfWork.Registro.EditAsync(registro);
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

        public Task<BaseResponse<BaseEntityResponse<RegistroResponseDTO>>> ListRegistros(BaseFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<RegistroSelectResponseDTO>>> ListSelectRegistros()
        {

            var response = new BaseResponse<IEnumerable<RegistroSelectResponseDTO>>();
            var registros = await _unitOfWork.Registro.GetAlltAsync();
            if (registros != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<IEnumerable<RegistroSelectResponseDTO>>(registros);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterRegistro(RegistroRequestDTO requestDTO)
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
            var registro = _mapper.Map<Registro>(requestDTO);
            registro.Id = Guid.NewGuid();
            response.Data = await _unitOfWork.Registro.RegisterAsync(registro);
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

        public async Task<BaseResponse<RegistroResponseDTO>> RegistroById(Guid id)
        {
            var response = new BaseResponse<RegistroResponseDTO>();
            var registro = await _unitOfWork.Registro.GetByIdAsync(id);
            if (registro != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<RegistroResponseDTO>(registro);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveRegistro(Guid registroId)
        {
            var response = new BaseResponse<bool>();
            var registroExists = await RegistroById(registroId);
            if (registroExists.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.Data = await _unitOfWork.Registro.RemoveAsync(registroId);
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
