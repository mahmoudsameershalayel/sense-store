using Sense.Application.DTOs.ProductDTOs;

namespace Sense.Application.UseCases.Product.Queries.GetWorstSellerItemsQuery
{
    public class GetWorstSellerItemsHandler : IRequestHandler<GetWorstSellerItemsQuery, ResponseResult<IEnumerable<ProductDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetWorstSellerItemsHandler(
            IRepositoryManager repositoryManager,
            IMapper mapper
          )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(
            GetWorstSellerItemsQuery request,
            CancellationToken cancellationToken)
        {

            var allOrders = await _repositoryManager.OrderDetails.GetAllOrderDetailsAsync();

            // Calculate date range based on Year and Month parameters
            DateTime startDate;
            DateTime endDate;

            if (request.Year.HasValue && request.Month.HasValue)
            {
                // Validate month is between 1-12
                if (request.Month.Value < 1 || request.Month.Value > 12)
                {
                    return ResponseResult<IEnumerable<ProductDto>>.GetResult(
                        ResultCodeStatus.BadRequest,
                        null,
                        "Month must be between 1 and 12"
                    );
                }

                // Filter by specific month
                startDate = new DateTime(request.Year.Value, request.Month.Value, 1);
                endDate = startDate.AddMonths(1);
            }
            else if (request.Year.HasValue)
            {
                // Validate year is reasonable
                if (request.Year.Value < 2020 || request.Year.Value > DateTime.UtcNow.Year + 1)
                {
                    return ResponseResult<IEnumerable<ProductDto>>.GetResult(
                        ResultCodeStatus.BadRequest,
                        null,
                        "Year must be between 2020 and " + (DateTime.UtcNow.Year + 1)
                    );
                }

                // Filter by entire year
                startDate = new DateTime(request.Year.Value, 1, 1);
                endDate = startDate.AddYears(1);
            }
            else
            {
                // Default: last 7 days
                startDate = DateTime.UtcNow.AddDays(-7);
                endDate = DateTime.UtcNow;
            }

            var bottomItems = allOrders
                .Where(oi => oi.Order.OrderDate.HasValue && oi.Order.OrderDate.Value >= startDate && oi.Order.OrderDate.Value < endDate)
                .GroupBy(oi => oi.ProductId)
                .OrderBy(g => g.Sum(x => x.ProductAmount))
                .Take(10)
                .Select(g => new
                        {
                            Product = g.First().Product,
                            TotalSales = g.Sum(x => x.ProductAmount)
                        })
                .ToList();

            var dtos = bottomItems.Select(x =>
            {
                var dto = _mapper.Map<ProductDto>(x.Product);
                dto.TotalSales = x.TotalSales;
                return dto;
            }).ToList();

            return ResponseResult<IEnumerable<ProductDto>>.GetResult(
                ResultCodeStatus.Success,
                dtos,
                "success"
                );
        }
    }

}
