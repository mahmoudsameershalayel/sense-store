using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum ResultCodeStatus
    {
        Success = 200,
        Created = 201,
        Deleted = 204,
        NotFound = 404,
        Forbiden = 403,
        BadRequest = 400,
        UnAuthorized = 401,
        Failed = 500,
    }
}
