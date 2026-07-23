using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<ResponseResult<bool>>
    {
        public int ProductId { get; set; }
    }
}
