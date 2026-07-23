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

namespace Sense.Application.UseCases.Product.Queries.GetBestSellerItemsQuery
{
    public class GetBestSellerItemsHandler : IRequestHandler<GetBestSellerItemsQuery, ResponseResult<IEnumerable<ProductDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetBestSellerItemsHandler(
            IRepositoryManager repositoryManager,
            IMapper mapper
          )
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(
            GetBestSellerItemsQuery request,
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

            var topItems = allOrders
                .Where(oi => oi.Order.OrderDate.HasValue && oi.Order.OrderDate.Value >= startDate && oi.Order.OrderDate.Value < endDate)
                .GroupBy(oi => oi.ProductId)
                .OrderByDescending(g => g.Sum(x => x.ProductAmount))
                .Take(10)
                .Select(g => new
                        {
                            Product = g.First().Product,
                            TotalSales = g.Sum(x => x.ProductAmount) 
                        }) 
                .ToList();

                var dtos = topItems.Select(x =>
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
