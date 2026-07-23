using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsByBranchIdQuery
{
    public class GetAllSupervisorsByBranchIdQuery : IRequest<ResponseResult<IEnumerable<SupervisorDto>>>
    {
        public int BranchId { get; set; }
    }
}