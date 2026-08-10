using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.ChangeProductStatusCommand
{
    public class ChangeProductStatusHandler : IRequestHandler<ChangeProductStatusCommand, ResponseResult<ProductDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ChangeProductStatusHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        private static bool IsProviderTransitionAllowed(ProductStatus current, ProductStatus target)
            => target == ProductStatus.Published
               && current is ProductStatus.Draft
                   or ProductStatus.PendingReview
                   or ProductStatus.Approved
                   or ProductStatus.Rejected
                   or ProductStatus.Unpublished;

        private static bool IsAdminTransitionAllowed(ProductStatus current, ProductStatus target)
        {
            return target switch
            {
                ProductStatus.Approved => current == ProductStatus.PendingReview,
                ProductStatus.Rejected => current == ProductStatus.PendingReview,
                ProductStatus.Published => current == ProductStatus.Approved || current == ProductStatus.Unpublished || current == ProductStatus.Draft,
                ProductStatus.Unpublished => current == ProductStatus.Published,
                ProductStatus.Archived => current != ProductStatus.Archived,
                ProductStatus.PendingReview => current == ProductStatus.Draft || current == ProductStatus.Rejected,
                _ => false
            };
        }

        public async Task<ResponseResult<ProductDto>> Handle(ChangeProductStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Product.GetProductByIdAsync(request.ProductId);
            if (entity is null)
                return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.NotFound, $"المنتج غير موجود!");

            if (request.ActingProviderId.HasValue)
            {
                if (entity.ProviderId != request.ActingProviderId)
                    return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.Forbiden, "لا تملك صلاحية على هذا المنتج!");

                if (!IsProviderTransitionAllowed(entity.Status, request.TargetStatus))
                    return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.BadRequest, "لا يمكن تغيير حالة المنتج من وضعه الحالي!");
            }
            else
            {
                if (!IsAdminTransitionAllowed(entity.Status, request.TargetStatus))
                    return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.BadRequest, "لا يمكن تغيير حالة المنتج من وضعه الحالي!");
            }

            entity.Status = request.TargetStatus;
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Product.UpdateProduct(entity);
            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<ProductDto>(entity);
            return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.Success, dto, "تم تحديث حالة المنتج بنجاح.");
        }
    }
}
