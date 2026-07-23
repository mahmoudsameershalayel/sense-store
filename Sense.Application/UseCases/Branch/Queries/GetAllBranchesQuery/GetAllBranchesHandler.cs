using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using AutoMapper;
using MediatR;

namespace Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery
{
	public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery, ResponseResult<IEnumerable<BranchDto>>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public GetAllBranchesHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<IEnumerable<BranchDto>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
		{

			var items = await _repositoryManager.Branch.GetAllBranchsAsync();
			var dtos = _mapper.Map<List<BranchDto>>(items);
			return ResponseResult<IEnumerable<BranchDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

		}
	}
}
