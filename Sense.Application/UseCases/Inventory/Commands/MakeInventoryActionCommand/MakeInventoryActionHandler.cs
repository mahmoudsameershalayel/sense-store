using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Inventory.Commands.MakeInventoryActionCommand
{
    public class MakeInventoryActionHandler : IRequestHandler<MakeInventoryActionCommand, ResponseResult<InventoryActionDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MakeInventoryActionHandler(
            IRepositoryManager repositoryManager,
            IMapper mapper
            )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<InventoryActionDto>> Handle(MakeInventoryActionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InventoryTbl>(request.Dto);

            var item = await _repositoryManager.Product.GetProductByIdAsync(request.Dto.ItemId);
            if (item is null)
                return ResponseResult<InventoryActionDto>.GetResult(
                    ResultCodeStatus.BadRequest,
                    "ItemBadRequest"
                );

            switch (request.Dto.Action)
            {
                case InventoryAction.Sold:
                    if (item.QuantityAvaliable < request.Dto.StockVal)
                        return ResponseResult<InventoryActionDto>.GetResult(
                            ResultCodeStatus.BadRequest,
                            "ItemOutOfStock"
                        );
                    item.QuantityAvaliable -= request.Dto.StockVal;
                    break;

                case InventoryAction.Restocked:
                    item.QuantityAvaliable += request.Dto.StockVal;
                    break;

                case InventoryAction.Returned:
                    item.QuantityAvaliable += request.Dto.StockVal;
                    break;
            }

            _repositoryManager.Product.UpdateProduct(item);

            _repositoryManager.Inventory.CreateInventoryAction(entity);

            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<InventoryActionDto>(entity);
            return ResponseResult<InventoryActionDto>.GetResult(
                ResultCodeStatus.Created,
                dto,
               "InventoryActionCreatedSuccessfully"
            );
        }
    }

}
