using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DomainEntities
{
    public class ResponseResult<TResult>
    {
        public ResultCode? Result { get; set; }
        public TResult? Data { get; set; }
        public static ResponseResult<TResult> GetResult(ResultCodeStatus code, TResult data, string message = "")
        {
            return new ResponseResult<TResult>()
            {
                Result = new ResultCode(code, message),
                Data = data
            };
        }
        public static ResponseResult<TResult> GetResult(ResultCodeStatus code, string message = "")
        {
            return new ResponseResult<TResult>()
            {
                Result = new ResultCode(code, message)
            };
        }
    }
}
