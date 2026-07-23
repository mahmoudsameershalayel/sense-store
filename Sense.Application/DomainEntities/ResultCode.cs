using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DomainEntities
{
    public class ResultCode
    {
        public ResultCode(ResultCodeStatus code, string message)
        {
            Code = code;
            Message = message;
        }
        public ResultCodeStatus Code { get; set; }
        public string? Message { get; set; }
    }
}
