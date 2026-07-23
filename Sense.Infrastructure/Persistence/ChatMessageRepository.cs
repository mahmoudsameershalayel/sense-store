using Sense.Application.CategoryRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.ChatMessageRepositories
{
    public class ChatMessageRepository : RepositoryBase<ChatMessageTbl>, IChatMessageRepository
    {
        public ChatMessageRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateChatMessage(ChatMessageTbl chatMessage)
            => Create(chatMessage);
      

        public void DeleteChatMessage(ChatMessageTbl chatMessage)
            => Delete(chatMessage);


        public async Task<IEnumerable<ChatMessageTbl>> GetAllChatMessagesAsync()
            => await FindAll().ToListAsync();
      

        public void UpdateChatMessage(ChatMessageTbl chatMessage)
        {
            throw new NotImplementedException();
        }
    }
}
