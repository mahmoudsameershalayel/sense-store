using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ChatMessage.Queries.GetAllUserChatMessageQuery
{
    public class GetAllUserChatMessageQuery : IRequest<ResponseResult<IEnumerable<ChatMessageTbl>>>
    {
        public required string UserId { get; set; }
    }
}