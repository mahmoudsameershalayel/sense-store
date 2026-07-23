using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<ResponseResult<UserDto>>
    {
        public string UserId { get; set; }
    }

}
