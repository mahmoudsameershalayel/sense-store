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

namespace Sense.Application.UseCases.Brand.Commands.DeleteBrandCommand
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public DeleteBrandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Brand.GetBrandByIdAsync(request.BrandId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The brand with Id : {request.BrandId} not exist in the database!!");

            

            _repositoryManager.Brand.DeleteBrand(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The brand with Id : {request.BrandId} deleted successfully");
        }
    }
}
