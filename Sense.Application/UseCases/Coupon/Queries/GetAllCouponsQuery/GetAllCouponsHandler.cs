using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Queries.GetAllCouponsQuery
{
    public class GetAllCouponsHandler : IRequestHandler<GetAllCouponsQuery, ResponseResult<IEnumerable<CouponDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllCouponsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<CouponDto>>> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.Coupon.GetAllCouponsAsync();
            var dtos = _mapper.Map<List<CouponDto>>(items);
            return ResponseResult<IEnumerable<CouponDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
