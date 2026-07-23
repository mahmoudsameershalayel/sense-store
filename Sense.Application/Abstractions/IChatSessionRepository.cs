using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IChatSessionRepository
    {
        Task<IEnumerable<ChatSessionTbl>> GetAllChatSessionsAsync();
        void CreateChatSession(ChatSessionTbl chatSession);
        void UpdateChatSession(ChatSessionTbl chatSession);
        void DeleteChatSession(ChatSessionTbl chatSession);
    }
}
