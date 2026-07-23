using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CouponDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.UpdateCouponCommand
{
    public class UpdateCouponCommand : IRequest<ResponseResult<CouponDto>>
    {
        public CouponForUpdateDto? Dto { get; set; }

    }
}