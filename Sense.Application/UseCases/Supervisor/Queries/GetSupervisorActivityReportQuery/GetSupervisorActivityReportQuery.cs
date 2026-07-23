using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Queries.GetSupervisorActivityReportQuery
{
    public class GetSupervisorActivityReportQuery : IRequest<ResponseResult<SupervisorReportDto>>
    {
        public string SupervisorId { get; set; }
    }
}