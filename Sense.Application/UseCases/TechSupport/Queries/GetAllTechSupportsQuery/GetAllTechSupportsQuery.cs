using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.DTOs.TechSupportDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.TechSupport.Queries.GetAllTechSupportsQuery
{
    public class GetAllTechSupportsQuery : IRequest<ResponseResult<IEnumerable<TechSupportDto>>>
    {
        public string? Name { get; set; }
    }
}