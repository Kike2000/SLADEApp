using AutoMapper;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.AreaResponse;
using CongresoSlade.Application.DTOs.Response.UserResponse;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Mappers
{
    //public class UserMappingProfile : Profile
    //{
    //    public UserMappingProfile()
    //    {

    //        CreateMap<AspNetUser, UserResponseDTO>()
    //           .ForMember(x => x.Id, x => x.MapFrom(y => y.Id));

    //        CreateMap<BaseEntityResponse<AspNetUser>, BaseEntityResponse<UserResponseDTO>>().ReverseMap();
    //        CreateMap<UserRequestDTO, AspNetUser>();
    //        CreateMap<AspNetUser, UserSelectResponseDTO>()
    //            .ForMember(x => x.Id, x => x.MapFrom(x => x.Id))
    //            .ReverseMap();
    //    }
    //}
}
