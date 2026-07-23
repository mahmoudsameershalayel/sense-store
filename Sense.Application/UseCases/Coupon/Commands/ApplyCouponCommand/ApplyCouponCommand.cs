using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CouponDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.ApplyCouponCommand
{
    public class ApplyCouponCommand : IRequest<ResponseResult<CouponResultDto>>
    {
        public ApplyCouponDto Dto { get; set; }
    }
}
