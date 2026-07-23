using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Queries.GetProviderByUserIdQuery
{
    public class GetProviderByUserIdQuery : IRequest<ResponseResult<ProviderDto>>
    {
        public string CurrentUserId { get; set; }
    }
}
