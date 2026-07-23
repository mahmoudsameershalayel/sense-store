using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Product.Commands.UpdateProductCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Commands.UpdateBannerCommand
{
    public class UpdateBannerHandler : IRequestHandler<UpdateBannerCommand, ResponseResult<BannerDto>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public UpdateBannerHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<BannerDto>> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
		{

			var entity = await _repositoryManager.Banner.GetHomeBannerByIdAsync(request.BannerId);
			if (entity is null)
				return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.NotFound, $"The Banner with Id : {request.BannerId} not exist in the database!!");

			_mapper.Map(request.Dto, entity);
			entity.ModifiedAt = DateTime.UtcNow;
			_repositoryManager.Banner.UpdateHomeBanner(entity);

			int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
			var dto = _mapper.Map<BannerDto>(entity);

			return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.Success, dto, $"The Banner with Id : {request.BannerId} updated successfully.");
		}
	}
}
