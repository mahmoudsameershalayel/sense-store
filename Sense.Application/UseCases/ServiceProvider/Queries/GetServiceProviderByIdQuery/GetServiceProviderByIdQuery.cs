using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceProviderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceProvider.Queries.GetServiceProviderByIdQuery
{
    public class GetServiceProviderByIdQuery : IRequest<ResponseResult<ServiceProviderDto>>
    {
        public int Id { get; set; }
    }
}
