using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Commands.DeleteBrandCommand
{
    public class DeleteBrandCommand : IRequest<ResponseResult<bool>>
    {
        public int BrandId { get; set; }
    }
}