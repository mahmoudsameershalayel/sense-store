using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<ResponseResult<PagedList<UserDto>>>
    {
        public UserType? UserType { get; set; }
        public UserParameters? UserParameters { get; set; }
    }

}
