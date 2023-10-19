using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Application.DTOs.Response.AreaResponse;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;

namespace CongresoSlade.Application.Interfaces
{
    public interface IAreaApplication
    {
        Task<BaseResponse<BaseEntityResponse<AreaResponseDTO>>> ListAreas(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<AreaSelectResponseDTO>>> ListSelectAreas();
        Task<BaseResponse<AreaResponseDTO>> AreaById(Guid id);
        Task<BaseResponse<bool>> RegisterArea(AreaRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditArea(Guid areaId, AreaRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveArea(Guid areaId);
    }
}
