using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ChatMessage.Queries.GetRelevantUsersByTechSupportIdQuery
{
    public class GetRelevantUsersByTechSupportIdHandler : IRequestHandler<GetRelevantUsersByTechSupportIdQuery, ResponseResult<IEnumerable<CustomerDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetRelevantUsersByTechSupportIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<CustomerDto>>> Handle(GetRelevantUsersByTechSupportIdQuery request, CancellationToken cancellationToken)
        {
            /*
            var techSupport = await _repositoryManager.TechSupport.GetTechSupportByApplicationUserId(request.CurrentUserId);
            if(techSupport is null)
                return ResponseResult<IEnumerable<UserDto>>.GetResult(ResultCodeStatus.NotFound, "Tech support not found!!");
                */
            var allSessions = await _repositoryManager.ChatSession.GetAllChatSessionsAsync();
            var allMessages = await _repositoryManager.ChatMessage.GetAllChatMessagesAsync();

            var usersWithSession = allSessions.Where(c => c.TechSupportId.Equals(request.CurrentUserId)).Select(c => c.UserId);

            var usersWhoSentMessagesNoReply = allMessages
               .Where(m => m.ReceiverId == null)
               .GroupBy(m => m.SenderId)
               .Where(g => !allMessages.Any(reply =>
                   reply.SenderId.Equals(request.CurrentUserId) &&
                   reply.ReceiverId == g.Key))
               .Select(g => g.Key);

            var userIds = usersWithSession
           .Union(usersWhoSentMessagesNoReply)
           .Distinct();

            var allUsers = await _repositoryManager.ApplicationUser.GetAllCustomersAsync(null);
            var users = allUsers.Where(x => userIds.Contains(x.ApplicationUserId)).ToList();
            var dtos = _mapper.Map<List<CustomerDto>>(users);
            return ResponseResult<IEnumerable<CustomerDto>>.GetResult(ResultCodeStatus.Success, dtos , "data reterived successfully");


        }
    }
}
