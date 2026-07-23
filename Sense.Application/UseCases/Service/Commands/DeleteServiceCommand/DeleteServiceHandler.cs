using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Banner.Commands.DeleteBannerCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.Abstractions;

namespace Sense.Application.UseCases.Service.Commands.DeleteServiceCommand
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageService;
        public DeleteServiceHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
        {
            _repositoryManager = repositoryManager;
            _imageService = imageServices;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Service.GetServiceByIdAsync(request.ServiceId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Service with Id : {request.ServiceId} not exist in the database!!");

            if (!string.IsNullOrEmpty(entity.ImageURL))
            {
                var deleteResult = await _imageService.DeleteImage(entity.ImageURL);

                if (deleteResult.Result.Code != ResultCodeStatus.Success)
                {
                    return deleteResult;
                }
            }

            _repositoryManager.Service.DeleteService(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Service with Id : {request.ServiceId} deleted successfully");
        }
    }
}
