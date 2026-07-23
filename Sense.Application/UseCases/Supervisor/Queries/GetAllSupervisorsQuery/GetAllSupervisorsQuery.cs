using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsQuery
{
    public class GetAllSupervisorsQuery : IRequest<ResponseResult<IEnumerable<SupervisorDto>>>
    {
    }
}