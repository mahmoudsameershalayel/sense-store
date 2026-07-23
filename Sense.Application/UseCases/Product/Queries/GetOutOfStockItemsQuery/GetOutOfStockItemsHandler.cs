using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.GetOutOfStockItemsQuery
{
    public class GetOutOfStockItemsHandler : IRequestHandler<GetOutOfStockItemsQuery, ResponseResult<IEnumerable<ProductDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOutOfStockItemsHandler(
            IRepositoryManager repositoryManager,
            IMapper mapper
          )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(
            GetOutOfStockItemsQuery request,
            CancellationToken cancellationToken)
        {

            var outOfStockItems = await _repositoryManager.Product.GetOutOfStockProducts();


            var dtos = _mapper.Map<List<ProductDto>>(outOfStockItems);

            return ResponseResult<IEnumerable<ProductDto>>.GetResult(
                ResultCodeStatus.Success,
                dtos,
                "success"
                );
        }
    }

}
