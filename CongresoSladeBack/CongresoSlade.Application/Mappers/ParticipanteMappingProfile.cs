using AutoMapper;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Mappers
{
    public class ParticipanteMappingProfile : Profile
    {
        public ParticipanteMappingProfile()
        {
            CreateMap<Participante, ParticipanteResponseDTO>()
               .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));

            CreateMap<BaseEntityResponse<Participante>, BaseEntityResponse<ParticipanteResponseDTO>>().ReverseMap();
            CreateMap<ParticipanteRequestDTO, Participante>();
            CreateMap<Participante, ParticipanteSelectResponseDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
                .ReverseMap();
        }
       
    }
}
