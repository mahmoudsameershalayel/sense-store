using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Queries.GetProviderByIdQuery
{
    public class GetProviderByIdQuery : IRequest<ResponseResult<ProviderDto>>
    {
        public int Id { get; set; }
    }
}
