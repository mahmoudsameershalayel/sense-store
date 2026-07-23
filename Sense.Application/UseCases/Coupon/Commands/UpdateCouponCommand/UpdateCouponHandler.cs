using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.UpdateCouponCommand
{
    public class UpdateCouponHandler : IRequestHandler<UpdateCouponCommand, ResponseResult<CouponDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateCouponHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CouponDto>> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {

            var entity = await _repositoryManager.Coupon.GetCouponByIdAsync(request.Dto.Id);
            if (entity is null)
                return ResponseResult<CouponDto>.GetResult(ResultCodeStatus.NotFound, $"The Coupon with Id : {request.Dto.Id} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Coupon.UpdateCoupon(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<CouponDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");
            var dto = _mapper.Map<CouponDto>(entity);

            return ResponseResult<CouponDto>.GetResult(ResultCodeStatus.Success, dto, $"The Coupon with Id : {request.Dto.Id} updated successfully.");
        }
    }
}
