using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Branch.Commands.UpdateBranchCommand
{
	public class UpdateBranchCommand : IRequest<ResponseResult<BranchDto>>
	{
		public int BranchId { get; set; }
		public BranchForCreateUpdateDto? Dto { get; set; }

	}
}