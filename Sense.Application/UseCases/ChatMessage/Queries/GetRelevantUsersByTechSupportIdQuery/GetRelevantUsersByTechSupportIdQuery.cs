using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ChatMessage.Queries.GetRelevantUsersByTechSupportIdQuery
{
    public class GetRelevantUsersByTechSupportIdQuery : IRequest<ResponseResult<IEnumerable<CustomerDto>>>
    {
        public required string CurrentUserId { get; set; }
    }
}
