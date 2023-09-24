using AutoMapper;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Response;

namespace CongresoSlade.Application.Mappers
{
    public class EventoMappingProfile : Profile
    {
        public EventoMappingProfile()
        {
            CreateMap<Evento, EventoResponseDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));

            CreateMap<BaseEntityResponse<Evento>, BaseEntityResponse<EventoResponseDTO>>().ReverseMap();
            CreateMap<EventoRequestDTO, Evento>();
            CreateMap<Evento, EventoSelectResponseDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
                .ReverseMap();
        }
    }
}
