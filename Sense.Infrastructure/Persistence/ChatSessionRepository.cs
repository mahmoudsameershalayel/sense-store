using Sense.Application.ChatMessageRepositories;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.ChatSessionRepositories
{
    public class ChatSessionRepository : RepositoryBase<ChatSessionTbl>, IChatSessionRepository
    {
        public ChatSessionRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateChatSession(ChatSessionTbl chatSession)
            => Create(chatSession);

        public void DeleteChatSession(ChatSessionTbl chatSession)
            => Delete(chatSession);

        public async Task<IEnumerable<ChatSessionTbl>> GetAllChatSessionsAsync()
            => await FindAll().ToListAsync();

        public void UpdateChatSession(ChatSessionTbl chatSession)
            => Update(chatSession);
    }
}
