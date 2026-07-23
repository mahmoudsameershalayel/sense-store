using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IChatMessageRepository
    {
        Task<IEnumerable<ChatMessageTbl>> GetAllChatMessagesAsync();
        void CreateChatMessage(ChatMessageTbl chatMessage);
        void UpdateChatMessage(ChatMessageTbl chatMessage);
        void DeleteChatMessage(ChatMessageTbl chatMessage);
    }
}
