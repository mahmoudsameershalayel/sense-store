using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Commands.DeleteServiceListingCommand
{
    public class DeleteServiceListingHandler : IRequestHandler<DeleteServiceListingCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
        public DeleteServiceListingHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
        {
            _repositoryManager = repositoryManager;
            _imageServices = imageServices;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteServiceListingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.ServiceListing.GetServiceListingByIdAsync(request.ServiceListingId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Service Listing with Id : {request.ServiceListingId} not exist in the database!!");

            if (!string.IsNullOrEmpty(entity.ImageURL))
                 await _imageServices.DeleteImage(entity.ImageURL);

            entity.IsDeleted = true;
            _repositoryManager.ServiceListing.UpdateServiceListing(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Service Listing with Id : {request.ServiceListingId} deleted successfully");
        }
    }
}
