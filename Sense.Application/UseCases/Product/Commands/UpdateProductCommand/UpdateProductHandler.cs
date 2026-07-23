using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.UpdateProductCommand
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResponseResult<ProductDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.Product.GetProductByIdAsync(request.ProductId);
            if (entity is null)
                return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.NotFound, $"The Product with Id : {request.ProductId} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Product.UpdateProduct(entity);

            await _repositoryManager.SaveAsync();
            var dto = _mapper.Map<ProductDto>(entity);

            return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.Success, dto, $"The Product with Id : {request.ProductId} updated successfully.");
        }
    }
}
