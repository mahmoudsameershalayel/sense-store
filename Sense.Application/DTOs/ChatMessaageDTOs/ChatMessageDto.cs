using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ChatMessaageDTOs
{
    public class ChatMessageDto
    {
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public bool IsSender { get; set; }
    }
}
