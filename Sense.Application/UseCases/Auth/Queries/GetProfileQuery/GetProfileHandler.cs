using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sense.Application.UseCases.Auth.Queries.GetProfileQuery
{
    public class GetProfileHandler : IRequestHandler<GetProfileQuery, ResponseResult<UserDto>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;

        public GetProfileHandler(UserManager<ApplicationUserTbl> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<UserDto>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.CurrentUserId);
            if (user is null)
            {
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.NotFound, $"المستخدم صاحب المعرف : {request.CurrentUserId} غير موجود!!");
            }
            var userDto = _mapper.Map<UserDto>(user);
            return ResponseResult<UserDto>.GetResult(ResultCodeStatus.Success, userDto, "تم إسترجاع بيانات المستخدم بنجاح");
        }
    }
}
