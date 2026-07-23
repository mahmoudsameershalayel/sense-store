using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.ChangeProductStatusCommand
{
    public class ChangeProductStatusCommand : IRequest<ResponseResult<ProductDto>>
    {
        public int ProductId { get; set; }
        public ProductStatus TargetStatus { get; set; }

        // When set, the acting user is a provider: ownership is enforced and
        // only the provider-allowed transitions are permitted.
        public int? ActingProviderId { get; set; }
    }
}
