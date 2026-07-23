using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery
{
    public class GetAllBannersQuery : IRequest<ResponseResult<IEnumerable<BannerDto>>>
	{

	}
}