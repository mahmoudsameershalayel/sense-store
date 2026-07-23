using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CouponDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Queries.GetActiveCouponsQuery
{
    public class GetActiveCouponsQuery : IRequest<ResponseResult<IEnumerable<CouponDto>>>
    {
    }
}