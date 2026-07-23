using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Commands.DeleteBannerCommand
{
    public class DeleteBannerCommand : IRequest<ResponseResult<bool>>
	{
		public int BannerId { get; set; }
	}
}
