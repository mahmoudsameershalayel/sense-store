using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ChatMessage.Queries.GetAllUserChatMessageQuery
{
    public class GetAllUserChatMessageHandler : IRequestHandler<GetAllUserChatMessageQuery, ResponseResult<IEnumerable<ChatMessageTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllUserChatMessageHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ChatMessageTbl>>> Handle(GetAllUserChatMessageQuery request, CancellationToken cancellationToken)
        {
            var allMessages = await _repositoryManager.ChatMessage.GetAllChatMessagesAsync();
            var userMessages = allMessages.Where(x => x.SenderId.Equals(request.UserId) || x.ReceiverId?.Equals(request.UserId) == true).ToList();
            return ResponseResult<IEnumerable<ChatMessageTbl>>.GetResult(ResultCodeStatus.Success, userMessages, "The data reterived successfully.");
        }
    }
}
