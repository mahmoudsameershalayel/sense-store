using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Commands.DeleteModelCommand
{
    public class DeleteModelCommand : IRequest<ResponseResult<bool>>
    {
        public required int ModelId { get; set; }
    }
}