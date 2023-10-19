using AutoMapper;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.RegistroResponse;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Response;

namespace CongresoSlade.Application.Mappers
{
    public class RegistroMappingProfile : Profile
    {
        public RegistroMappingProfile()
        {
            CreateMap<Registro, RegistroResponseDTO>()
               .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));

            CreateMap<BaseEntityResponse<Registro>, BaseEntityResponse<RegistroResponseDTO>>().ReverseMap();
            CreateMap<RegistroRequestDTO, Registro>();
            CreateMap<Registro, RegistroSelectResponseDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
                .ReverseMap();
        }
    }
}
