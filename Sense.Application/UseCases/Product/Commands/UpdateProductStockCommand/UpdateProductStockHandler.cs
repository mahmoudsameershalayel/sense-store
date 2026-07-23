using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using Sense.Application.UseCases.Inventory.Commands.MakeInventoryActionCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.UpdateProductStockCommand
{
    public class UpdateProductStockHandler : IRequestHandler<UpdateProductStockCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateProductStockHandler(
            IRepositoryManager repositoryManager,
            IMapper mapper
            )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {

            var item = await _repositoryManager.Product.GetProductByIdAsync(request.Dto.ItemId);
            if (item is null)
                return ResponseResult<bool>.GetResult(
                    ResultCodeStatus.BadRequest,
                    false,
                    "ItemBadRequest"
                );

            item.QuantityAvaliable = request.Dto.NewStockVal; 
            _repositoryManager.Product.UpdateProduct(item);


            await _repositoryManager.SaveAsync();

            return ResponseResult<bool>.GetResult(
                ResultCodeStatus.Created,
                true,
               "InventoryActionCreatedSuccessfully"
            );
        }
    }

}