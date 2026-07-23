using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.DeleteProductCommand
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
        public DeleteProductHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
        {
            _repositoryManager = repositoryManager;
            _imageServices = imageServices;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Product.GetProductByIdAsync(request.ProductId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Product with Id : {request.ProductId} not exist in the database!!");

            if (!string.IsNullOrEmpty(entity.ImageURL))
                 await _imageServices.DeleteImage(entity.ImageURL);

            entity.IsDeleted = true;
            _repositoryManager.Product.UpdateProduct(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Product with Id : {request.ProductId} deleted successfully");
        }
    }
}
