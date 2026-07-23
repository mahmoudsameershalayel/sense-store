using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Commands.DeleteModelCommand
{
    public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public DeleteModelHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Model.GetBrandTypeByIdAsync(request.ModelId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The brand type with Id : {request.ModelId} not exist in the database!!");


            _repositoryManager.Model.DeleteBrandType(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The brand type with Id : {request.ModelId} deleted successfully");
        }
    }
}
