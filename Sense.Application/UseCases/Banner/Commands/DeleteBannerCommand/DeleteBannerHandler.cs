using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Product.Commands.DeleteProductCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Commands.DeleteBannerCommand
{
    public class DeleteBannerHandler : IRequestHandler<DeleteBannerCommand, ResponseResult<bool>>
	{
		private readonly IRepositoryManager _repositoryManager;
		public DeleteBannerHandler(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<ResponseResult<bool>> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
		{
			var entity = await _repositoryManager.Banner.GetHomeBannerByIdAsync(request.BannerId);
			if (entity is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Banner with Id : {request.BannerId} not exist in the database!!");

			/*if (!string.IsNullOrEmpty(entity.ImageURL))
			{

                if (deleteResult.Result.Code != ResultCodeStatus.Success)
                {
					return deleteResult;
                }
            }*/

			_repositoryManager.Banner.DeleteHomeBanner(entity);
			await _repositoryManager.SaveAsync();
			return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Banner with Id : {request.BannerId} deleted successfully");
		}
	}
}
