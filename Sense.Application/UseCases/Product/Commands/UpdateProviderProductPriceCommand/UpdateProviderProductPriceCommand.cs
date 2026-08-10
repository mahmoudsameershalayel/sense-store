using MediatR;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.Product.Commands.UpdateProviderProductPriceCommand
{
    public class UpdateProviderProductPriceCommand : IRequest<ResponseResult<decimal>>
    {
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public decimal Price { get; set; }
    }
}
