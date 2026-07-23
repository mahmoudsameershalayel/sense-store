using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetUserByIdQuery
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResponseResult<UserDto>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(UserManager<ApplicationUserTbl> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<ResponseResult<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Where(x => x.Id.Equals(request.UserId)).FirstOrDefaultAsync();
            if (user is null)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.NotFound, "User not found");

            var dto = _mapper.Map<UserDto>(user);

            return ResponseResult<UserDto>.GetResult(ResultCodeStatus.Success, dto, "User retrieved successfully");
        }
    }
}
