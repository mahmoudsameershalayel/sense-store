using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Product.Commands.CreateProductCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Commands.CreateBannerCommand
{
    public class CreateBannerHandler : IRequestHandler<CreateBannerCommand, ResponseResult<BannerDto>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public CreateBannerHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<BannerDto>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<BannerTbl>(request.Dto);
			_repositoryManager.Banner.CreateHomeBanner(entity);

			int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

			var dto = _mapper.Map<BannerDto>(entity);
			return ResponseResult<BannerDto>.GetResult(ResultCodeStatus.Created, dto, $"The Banner with Id : {entity.Id} created successfully");
		}
	}
}

