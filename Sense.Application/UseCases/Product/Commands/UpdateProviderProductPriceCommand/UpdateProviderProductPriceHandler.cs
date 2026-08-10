using MediatR;
using Sense.Application.DomainEntities;
using Sense.Domain.Enums;

namespace Sense.Application.UseCases.Product.Commands.UpdateProviderProductPriceCommand
{
    public class UpdateProviderProductPriceHandler
        : IRequestHandler<UpdateProviderProductPriceCommand, ResponseResult<decimal>>
    {
        private const decimal MaximumPrice = 9999999999999999.99m;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateProviderProductPriceHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<decimal>> Handle(
            UpdateProviderProductPriceCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Price < 0 || request.Price > MaximumPrice)
            {
                return ResponseResult<decimal>.GetResult(
                    ResultCodeStatus.BadRequest,
                    "السعر المدخل غير صالح.");
            }

            var product = await _repositoryManager.Product.GetProductByIdAsync(request.ProductId);
            if (product is null)
            {
                return ResponseResult<decimal>.GetResult(
                    ResultCodeStatus.NotFound,
                    "المنتج غير موجود.");
            }

            if (product.ProviderId != request.ProviderId)
            {
                return ResponseResult<decimal>.GetResult(
                    ResultCodeStatus.Forbiden,
                    "لا تملك صلاحية تعديل هذا المنتج.");
            }

            if (product.Status == ProductStatus.Archived)
            {
                return ResponseResult<decimal>.GetResult(
                    ResultCodeStatus.BadRequest,
                    "لا يمكن تعديل سعر منتج مؤرشف.");
            }

            product.Price = decimal.Round(request.Price, 2, MidpointRounding.AwayFromZero);
            product.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Product.UpdateProduct(product);
            await _repositoryManager.SaveAsync();

            return ResponseResult<decimal>.GetResult(
                ResultCodeStatus.Success,
                product.Price,
                "تم حفظ السعر بنجاح.");
        }
    }
}
