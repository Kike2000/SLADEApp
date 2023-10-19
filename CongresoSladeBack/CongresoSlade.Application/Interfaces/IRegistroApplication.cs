using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.RegistroResponse;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;

namespace CongresoSlade.Application.Interfaces
{
    public interface IRegistroApplication
    {
        Task<BaseResponse<BaseEntityResponse<RegistroResponseDTO>>> ListRegistros(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<RegistroSelectResponseDTO>>> ListSelectRegistros();
        Task<BaseResponse<RegistroResponseDTO>> RegistroById(Guid id);
        Task<BaseResponse<bool>> RegisterRegistro(RegistroRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditRegistro(Guid registroId, RegistroRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveRegistro(Guid registroId);
    }
}
