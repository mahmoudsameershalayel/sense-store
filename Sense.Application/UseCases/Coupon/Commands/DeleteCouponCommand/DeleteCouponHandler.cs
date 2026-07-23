using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Coupon.Commands.DeleteCouponCommand
{
    public class DeleteCouponHandler : IRequestHandler<DeleteCouponCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DeleteCouponHandler(IRepositoryManager repositoryManager , IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Coupon.GetCouponByIdAsync(request.CouponId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The category with Id : {request.CouponId} not exist in the database!!");
            
            entity.IsDeleted = true;
            
            _repositoryManager.Coupon.UpdateCoupon(entity);
            await _repositoryManager.SaveAsync();
            
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Coupon with Id : {request.CouponId} deleted successfully");
        }
    }
}
