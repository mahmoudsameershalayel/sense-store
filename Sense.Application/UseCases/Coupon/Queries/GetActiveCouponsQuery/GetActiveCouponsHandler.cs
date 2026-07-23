using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CouponDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Queries.GetActiveCouponsQuery
{
    public class GetActiveCouponsHandler : IRequestHandler<GetActiveCouponsQuery, ResponseResult<IEnumerable<CouponDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetActiveCouponsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<CouponDto>>> Handle(GetActiveCouponsQuery request, CancellationToken cancellationToken)
        {

            var coupons = await _repositoryManager.Coupon.GetAllCouponsAsync();
            var activeCoupons = coupons.Where(x => x.IsActive == true && DateTime.UtcNow >= x.StartDate && DateTime.UtcNow <= x.EndDate).ToList();
            var dtos = _mapper.Map<List<CouponDto>>(activeCoupons);
            return ResponseResult<IEnumerable<CouponDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}