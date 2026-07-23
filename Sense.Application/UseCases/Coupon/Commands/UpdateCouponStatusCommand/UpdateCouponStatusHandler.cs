using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.CashbackOffer.Commands.UpdateCashbackOfferStatusCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.UpdateCouponStatusCommand
{
    public class UpdateCouponStatusHandler : IRequestHandler<UpdateCouponStatusCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public UpdateCouponStatusHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateCouponStatusCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _repositoryManager.Coupon.GetCouponByIdAsync(request.CouponId);
            if (coupon is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The coupon with id : {request.CouponId} Not Found!!");

            coupon.IsActive = !coupon.IsActive;

            _repositoryManager.Coupon.UpdateCoupon(coupon);
            var result = await _repositoryManager.SaveAsync();
            if (result != 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The coupon with id : {coupon.Id} Updated successfully");
          
            return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The Operation Failed!!");
        }


    }
}
