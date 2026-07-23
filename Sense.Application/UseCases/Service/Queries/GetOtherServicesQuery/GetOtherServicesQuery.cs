using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Queries.GetOtherServicesQuery
{
    public class GetOtherServicesQuery : IRequest<ResponseResult<IEnumerable<ServiceDto>>>
    {
        public int ServiceId { get; set; }
    }
}