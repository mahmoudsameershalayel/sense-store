using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public DeleteCategoryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Category.GetCategoryByIdAsync(request.CategoryId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The category with Id : {request.CategoryId} not exist in the database!!");


            /*if (!string.IsNullOrEmpty(entity.ImageURL))
                await ImageServices.DeleteImage(entity.ImageURL);*/

            _repositoryManager.Category.DeleteCategory(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The category with Id : {request.CategoryId} deleted successfully");
        }
    }
}
