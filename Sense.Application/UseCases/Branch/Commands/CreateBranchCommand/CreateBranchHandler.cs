using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using Sense.Application.UseCases.Banner.Commands.CreateBannerCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.Branch.Commands.CreateBranchCommand
{
	public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, ResponseResult<BranchDto>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public CreateBranchHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<BranchDto>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<BranchTbl>(request.Dto);
			_repositoryManager.Branch.CreateBranch(entity);

			int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

			var dto = _mapper.Map<BranchDto>(entity);
			return ResponseResult<BranchDto>.GetResult(ResultCodeStatus.Created, dto, $"The Branch with Id : {entity.Id} created successfully");
		}
	}
}

