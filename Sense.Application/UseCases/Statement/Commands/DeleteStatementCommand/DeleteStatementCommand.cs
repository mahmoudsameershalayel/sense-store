using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Commands.DeleteStatementCommand
{
    public class DeleteStatementCommand : IRequest<ResponseResult<bool>>
    {
        public int StatementId { get; set; }
    }
}
