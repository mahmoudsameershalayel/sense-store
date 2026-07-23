using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest<ResponseResult<bool>>
    {
        public int CategoryId { get; set; }
    }
}
