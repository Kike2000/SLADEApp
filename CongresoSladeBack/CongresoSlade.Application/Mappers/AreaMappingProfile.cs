using AutoMapper;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.AreaResponse;
using CongresoSlade.Application.DTOs.Response.EventoResponse;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Response;

namespace CongresoSlade.Application.Mappers
{
    public class AreaMappingProfile : Profile
    {
        public AreaMappingProfile()
        {
            CreateMap<Area, AreaResponseDTO>()
               .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));

            CreateMap<BaseEntityResponse<Area>, BaseEntityResponse<AreaResponseDTO>>().ReverseMap();
            CreateMap<AreaRequestDTO, Area>();
            CreateMap<Area, AreaSelectResponseDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
                .ReverseMap();
        }

    }
}
