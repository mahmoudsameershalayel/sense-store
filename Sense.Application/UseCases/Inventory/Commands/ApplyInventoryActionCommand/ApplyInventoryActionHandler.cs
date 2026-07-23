using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Inventory.Commands.ApplyInventoryActionCommand
{
    public class ApplyInventoryActionHandler : IRequestHandler<ApplyInventoryActionCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ApplyInventoryActionHandler(
            IRepositoryManager repositoryManager,
            IMapper mapper
            )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(ApplyInventoryActionCommand request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.Product.GetAllProductsAsync(null);

            if (!items.Any())
            {
                return ResponseResult<bool>.GetResult(
                    ResultCodeStatus.Success,
                    true,
                    "success"
                );
            }

            foreach (var item in items)
            {
                // Create inventory action log for each item
                var entity = _mapper.Map<InventoryTbl>(request.Dto);
                entity.ItemId = item.Id; // important
                entity.StockVal = request.Dto.StockVal; // same value applied to all

                switch (request.Dto.Action)
                {
                    case InventoryAction.Sold:
                        if (item.QuantityAvaliable < request.Dto.StockVal)
                        {
                            return ResponseResult<bool>.GetResult(
                                ResultCodeStatus.BadRequest,
                                "ItemOutOfStock"
                            );
                        }
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
            }

            await _repositoryManager.SaveAsync();


            return ResponseResult<bool>.GetResult(
                ResultCodeStatus.Created,
                true,
                "InventoryActionCreatedSuccessfully");
        }
    }

}
