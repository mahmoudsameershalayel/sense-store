using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery
{
    public class GetAllBannersHandler : IRequestHandler<GetAllBannersQuery, ResponseResult<IEnumerable<BannerDto>>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public GetAllBannersHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<IEnumerable<BannerDto>>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
		{

			var items = await _repositoryManager.Banner.GetAllHomeBannersAsync();
			var dtos = _mapper.Map<List<BannerDto>>(items);
			return ResponseResult<IEnumerable<BannerDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

		}
	}
}
