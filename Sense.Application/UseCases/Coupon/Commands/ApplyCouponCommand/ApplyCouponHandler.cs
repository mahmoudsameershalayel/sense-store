using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CouponDTOs;
using MediatR;


namespace Sense.Application.UseCases.Coupon.Commands.ApplyCouponCommand
{
    public class ApplyCouponHandler : IRequestHandler<ApplyCouponCommand, ResponseResult<CouponResultDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public ApplyCouponHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<CouponResultDto>> Handle(ApplyCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _repositoryManager.Coupon.GetCouponAsync(request.Dto.CouponCode);
            if(coupon is null || !coupon.IsActive)
                return ResponseResult<CouponResultDto>.GetResult(ResultCodeStatus.NotFound, $"الكوبون : {request.Dto.CouponCode} غير موجود , غير صالح أو معطل!!");
          
            if (DateTime.UtcNow < coupon.StartDate || DateTime.UtcNow > coupon.EndDate)
                return ResponseResult<CouponResultDto>.GetResult(ResultCodeStatus.BadRequest, $"الكوبون منتهي الصلاحية!!");

  
            decimal discountAmount = 0;
            if (coupon.DiscountType == OfferDiscountType.Percentage)
            {
                discountAmount = request.Dto.TotalAmount * (coupon.DiscountAmount / 100);
            } else if(coupon.DiscountType == OfferDiscountType.Fixed)
            {
                discountAmount = coupon.DiscountAmount;

            }
            if (discountAmount > request.Dto.TotalAmount)
            {
                discountAmount = request.Dto.TotalAmount;
            }

            var finalAmount = request.Dto.TotalAmount - discountAmount;

            var result = new CouponResultDto { DiscountAmount = discountAmount, FinalAmount = finalAmount };
            return ResponseResult<CouponResultDto>.GetResult(ResultCodeStatus.Success,result , $"Coupon applied successfully! You saved {discountAmount:C}. Total after discount: {finalAmount:C}.");
        }
    }
}
