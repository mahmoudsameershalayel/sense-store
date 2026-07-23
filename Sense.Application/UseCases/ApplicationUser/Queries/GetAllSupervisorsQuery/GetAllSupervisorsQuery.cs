using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetAllSupervisorsQuery
{
    public class GetAllSupervisorsQuery : IRequest<ResponseResult<IEnumerable<SupervisorTbl>>>
    {
        public string? Name { get; set; }
    }

}
