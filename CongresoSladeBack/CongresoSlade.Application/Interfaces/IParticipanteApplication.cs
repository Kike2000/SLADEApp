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
    public interface IParticipanteApplication
    {
        Task<BaseResponse<BaseEntityResponse<ParticipanteResponseDTO>>> ListParticipantes(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<ParticipanteSelectResponseDTO>>> ListSelectParticipantes();
        Task<BaseResponse<ParticipanteResponseDTO>> ParticipanteById(Guid id);
        Task<BaseResponse<bool>> RegisterParticipante(ParticipanteRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditParticipante(Guid participanteId, ParticipanteRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveParticipante(Guid participanteId);
    }
}
