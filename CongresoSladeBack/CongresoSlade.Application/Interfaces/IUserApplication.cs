using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.AreaResponse;
using CongresoSlade.Application.DTOs.Response.UserResponse;
using CongresoSlade.Infrastructure.Commons.Bases.Request;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Interfaces
{
    public interface IUserApplication
    {
        //Task<BaseResponse<BaseEntityResponse<UserResponseDTO>>> ListUsers(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<UserSelectResponseDTO>>> ListSelectUsers();
        Task<BaseResponse<UserResponseDTO>> UserById(Guid id);
        Task<BaseResponse<bool>> RegisterUser(UserRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditUser(Guid userId, UserRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveUser(Guid userId);
    }
}
