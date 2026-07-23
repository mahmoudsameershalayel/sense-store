using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateOrderStatusHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        private async Task UpdateInventory(OrderTbl order)
        {
            foreach (var orderItem in order.OrderDetails)
            {
                var product = await _repositoryManager.Product.GetProductByIdAsync(orderItem.ProductId);
                if (product is null)
                    continue;

                var quantity = (int)(orderItem.ProductAmount ?? 0);
                if (quantity <= 0)
                    continue;

                if (quantity > product.QuantityAvaliable)
                    throw new InvalidOperationException("لا يوجد كمية متاحة من المنتج!!");

                product.QuantityAvaliable -= quantity;
                _repositoryManager.Product.UpdateProduct(product);

                var inventoryAction = new InventoryTbl
                {
                    ItemId = product.Id,
                    StockVal = quantity,
                    Action = InventoryAction.Sold,
                    Date = DateTime.UtcNow
                };
                _repositoryManager.Inventory.CreateInventoryAction(inventoryAction);
            }
        }

        public async Task<ResponseResult<bool>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _repositoryManager.Order.GetOrderById(request.Dto.OrderId);
            if (order is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "Not Found!!");

            var shouldMoveStock = request.Dto.NewStatus == OrderStatus.OutForDelivery && order.OutForDeliveryTime is null;
            if (shouldMoveStock)
            {
                try
                {
                    await UpdateInventory(order);
                    order.OutForDeliveryTime = DateTime.UtcNow;
                }
                catch (InvalidOperationException ex)
                {
                    return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, ex.Message);
                }
            }

            order.OrderStatus = request.Dto.NewStatus;
            _repositoryManager.Order.UpdateOrderAll(order);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "Order Status Updated Successfully!!");
        }
    }
}
