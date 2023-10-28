using AutoMapper;
using CongresoSlade.Application.Commons.Bases;
using CongresoSlade.Application.DTOs.Request;
using CongresoSlade.Application.DTOs.Response.UserResponse;
using CongresoSlade.Application.Interfaces;
using CongresoSlade.Application.Validators.Area;
using CongresoSlade.Application.Validators.User;
using CongresoSlade.Domain.Entities;
using CongresoSlade.Infrastructure.Persistences.Interfaces;
using CongresoSlade.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoSlade.Application.Services
{
    //public class UserApplication : IUserApplication
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;
    //    private readonly UserValidator _validationRules;

    //    public UserApplication(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //        _validationRules = new UserValidator();
    //    }
    //    public Task<BaseResponse<IEnumerable<UserSelectResponseDTO>>> ListSelectUsers()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public async Task<BaseResponse<bool>> RegisterUser(UserRequestDTO requestDTO)
    //    //{

    //    //    var response = new BaseResponse<bool>();
    //    //    var validationResult = await _validationRules.ValidateAsync(requestDTO);
    //    //    if (!validationResult.IsValid)
    //    //    {
    //    //        response.IsSucessful = false;
    //    //        response.Message = ReplyMessage.MESSAGE_VALIDATE;
    //    //        response.Errors = validationResult.Errors;
    //    //        return response;
    //    //    }
    //    //    var user = _mapper.Map<AspNetUser>(requestDTO);
    //    //    response.Data = await _unitOfWork.User.RegisterUserAsync(user);
    //    //    if (response.Data)
    //    //    {
    //    //        response.IsSucessful = true;
    //    //        response.Message = ReplyMessage.MESSAGE_SAVE;
    //    //    }
    //    //    else
    //    //    {
    //    //        response.IsSucessful = false;
    //    //        response.Message = ReplyMessage.MESSAGE_FAIL;
    //    //    }
    //    //    return response;
    //    //}
    //    public Task<BaseResponse<bool>> EditUser(Guid userId, UserRequestDTO requestDTO)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<BaseResponse<bool>> RemoveUser(Guid userId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<BaseResponse<UserResponseDTO>> UserById(Guid id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
