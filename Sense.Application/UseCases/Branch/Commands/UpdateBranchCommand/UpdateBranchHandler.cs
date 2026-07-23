using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using Sense.Application.UseCases.Banner.Commands.UpdateBannerCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Branch.Commands.UpdateBranchCommand
{
	public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, ResponseResult<BranchDto>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public UpdateBranchHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<BranchDto>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
		{

			var entity = await _repositoryManager.Branch.GetBranchByIdAsync(request.BranchId);
			if (entity is null)
				return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.NotFound, $"The Banner with Id : {request.BranchId} not exist in the database!!");

			_mapper.Map(request.Dto, entity);
			entity.ModifiedAt = DateTime.UtcNow;
			_repositoryManager.Branch.UpdateBranch(entity);

			int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
			var dto = _mapper.Map<BranchDto>(entity);

			return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.Success, dto, $"The Branch with Id : {request.BranchId} updated successfully.");
		}
	}
}
