using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Inventory.Commands.MakeInventoryActionCommand
{
    public class MakeInventoryActionCommand : IRequest<ResponseResult<InventoryActionDto>>
    {
        public InventoryActionForCreateDto? Dto { get; set; }
    }
}
