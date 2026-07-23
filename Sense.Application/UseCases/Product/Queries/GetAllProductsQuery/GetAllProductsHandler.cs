using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using AutoMapper;
using MediatR;

namespace Sense.Application.UseCases.Product.Queries.GetAllProductsQuery
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ResponseResult<IEnumerable<ProductDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var itemsWithMetaData = await _repositoryManager.Product.GetAllProductsAsync(request.ProductParameters);
            var dtos = _mapper.Map<List<ProductDto>>(itemsWithMetaData);
            return ResponseResult<IEnumerable<ProductDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
