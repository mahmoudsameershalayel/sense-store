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

namespace Sense.Application.UseCases.Branch.Commands.DeleteBranchCommand
{
	public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, ResponseResult<bool>>
	{
		private readonly IRepositoryManager _repositoryManager;
		public DeleteBranchHandler(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<ResponseResult<bool>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
		{
			var entity = await _repositoryManager.Branch.GetBranchByIdAsync(request.BranchId);
			if (entity is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Branch with Id : {request.BranchId} not exist in the database!!");

			_repositoryManager.Branch.DeleteBranch(entity);
			await _repositoryManager.SaveAsync();
			return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Branch with Id : {request.BranchId} deleted successfully");
		}
	}
}
