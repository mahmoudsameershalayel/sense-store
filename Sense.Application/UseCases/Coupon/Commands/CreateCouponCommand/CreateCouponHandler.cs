using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.CreateCouponCommand
{
    public class CreateCouponHandler : IRequestHandler<CreateCouponCommand, ResponseResult<CouponDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateCouponHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CouponDto>> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CouponTbl>(request.Dto);
            _repositoryManager.Coupon.CreateCoupon(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<CouponDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<CouponDto>(entity);
            return ResponseResult<CouponDto>.GetResult(ResultCodeStatus.Created, dto, $"The Coupon with Id : {entity.Id} created successfully");
        }
    }
}
