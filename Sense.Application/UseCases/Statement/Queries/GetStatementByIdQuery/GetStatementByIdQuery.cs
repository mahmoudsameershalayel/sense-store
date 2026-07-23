using Sense.Application.DomainEntities;
using Sense.Application.DTOs.StatementDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Queries.GetStatementByIdQuery
{
    public class GetStatementByIdQuery : IRequest<ResponseResult<StatementDto>>
    {
        public int StatementId { get; set; }
    }
}
