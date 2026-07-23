using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Inventory.Commands.ApplyInventoryActionCommand
{
    public class ApplyInventoryActionCommand : IRequest<ResponseResult<bool>>
    {
        public ApplyInventoryActionDto? Dto { get; set; }
    }
}
