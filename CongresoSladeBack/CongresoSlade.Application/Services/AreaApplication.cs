using AutoMapper;
using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.AreaResponse;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Validators.Area;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using CongresoSlade.Utilities.Static;
using Microsoft.Extensions.Logging;

namespace CongresoSlade.Application.Services
{
    public class AreaApplication : IAreaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AreaValidator _validationRules;
        public AreaApplication(IUnitOfWork unitOfWork, IMapper mapper, AreaValidator validationRules)
        {
            _mapper = mapper;
            _validationRules = validationRules;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<AreaResponseDTO>> AreaById(Guid id)
        {
            var response = new BaseResponse<AreaResponseDTO>();
            var area = await _unitOfWork.Area.GetByIdAsync(id);
            if (area != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<AreaResponseDTO>(area);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditArea(Guid areaId, AreaRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var areaEdit = await AreaById(areaId);
            if (areaEdit.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var area = _mapper.Map<Area>(requestDTO);
            area.Id = areaId;
            response.Data = await _unitOfWork.Area.EditAsync(area);
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

        public Task<BaseResponse<BaseEntityResponse<AreaResponseDTO>>> ListAreas(BaseFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<AreaSelectResponseDTO>>> ListSelectAreas()
        {
            var response = new BaseResponse<IEnumerable<AreaSelectResponseDTO>>();
            var areas = await _unitOfWork.Area.GetAlltAsync();
            if (areas != null)
            {
                response.IsSucessful = true;
                response.Data = _mapper.Map<IEnumerable<AreaSelectResponseDTO>>(areas);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucessful = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterArea(AreaRequestDTO requestDTO)
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
            var area = _mapper.Map<Area>(requestDTO);
            area.Id = Guid.NewGuid();
            response.Data = await _unitOfWork.Area.RegisterAsync(area);
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

        public async Task<BaseResponse<bool>> RemoveArea(Guid areaId)
        {

            var response = new BaseResponse<bool>();
            var areaExists = await AreaById(areaId);
            if (areaExists.Data == null)
            {
                response.IsSucessful = true;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.Data = await _unitOfWork.Area.RemoveAsync(areaId);
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
