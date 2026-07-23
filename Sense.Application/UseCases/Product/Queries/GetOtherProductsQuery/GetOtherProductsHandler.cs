using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.UseCases.Service.Queries.GetOtherServicesQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.Product.Queries.GetOtherProductsQuery
{
    public class GetOtherProductsHandler : IRequestHandler<GetOtherProductsQuery, ResponseResult<IEnumerable<ProductDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetOtherProductsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(GetOtherProductsQuery request, CancellationToken cancellationToken)
        {

            var products = await _repositoryManager.Product.GetAllProductsAsync(new ProductParameters { Status = ProductStatus.Published });
            var otherProducts = products.Where(x => x.Id != request.ProductId).ToList();
            var dtos = _mapper.Map<List<ProductDto>>(otherProducts);
            return ResponseResult<IEnumerable<ProductDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
