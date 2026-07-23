using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using Sense.Application.UseCases.Banner.Queries.GetBannerByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Branch.Queries.GetBranchByIdQuery
{
	public class GetBranchByIdHandler : IRequestHandler<GetBranchByIdQuery, ResponseResult<BranchDto>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public GetBranchByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<BranchDto>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _repositoryManager.Branch.GetBranchByIdAsync(request.BranchId);
			if (entity is null)
				return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.NotFound, $"The Branch with Id : {request.BranchId} not exist in the database!!");
			var dto = _mapper.Map<BranchDto>(entity);
			return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
		}
	}
}
