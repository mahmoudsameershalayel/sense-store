using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.UpdateCouponStatusCommand
{
    public class UpdateCouponStatusCommand : IRequest<ResponseResult<bool>>
    {
        public int CouponId { get; set; }
    }
}
