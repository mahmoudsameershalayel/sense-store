using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.PointsDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Points.Queries.GetPointsTransactionQuery
{
    public class GetPointsTransactionHandler : IRequestHandler<GetPointsTransactionQuery, ResponseResult<PointsTransactionDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;

        public GetPointsTransactionHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PointsTransactionDto>> Handle(GetPointsTransactionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get customer information to validate ownership
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
                if (customer == null)
                {
                    return ResponseResult<PointsTransactionDto>.GetResult(ResultCodeStatus.NotFound, 
                        "«·⁄„Ì· €Ì— „ÊÃÊœ!");
                }

                // Get transaction based on order or maintenance record
                PointsTransactionTbl? transaction = null;
                
                if (request.OrderId.HasValue)
                {
                    transaction = await _repositoryManager.PointsTransaction.GetPointsTransactionByOrderIdAsync(request.OrderId.Value);
                }
                else if (request.MaintenanceRecordId.HasValue)
                {
                    transaction = await _repositoryManager.PointsTransaction.GetPointsTransactionByMaintenanceRecordIdAsync(request.MaintenanceRecordId.Value);
                }

                if (transaction == null)
                {
                    return ResponseResult<PointsTransactionDto>.GetResult(ResultCodeStatus.NotFound, 
                        "·„ Ì „ «·⁄ÀÊ— ⁄·Ï „⁄«„·… «·‰ﬁ«ÿ");
                }

                // Validate that the transaction belongs to the current customer
                if (transaction.CustomerId != customer.Id)
                {
                    return ResponseResult<PointsTransactionDto>.GetResult(ResultCodeStatus.Failed, 
                        "€Ì— „”„ÊÕ ·ﬂ »«·Ê’Ê· ≈·Ï Â–Â «·„⁄«„·…");
                }

                var transactionDto = _mapper.Map<PointsTransactionDto>(transaction);

                return ResponseResult<PointsTransactionDto>.GetResult(ResultCodeStatus.Success, transactionDto, 
                    " „ «” —œ«œ  ›«’Ì· «·„⁄«„·… »‰Ã«Õ");
            }
            catch (Exception)
            {
                return ResponseResult<PointsTransactionDto>.GetResult(ResultCodeStatus.Failed, 
                    "ÕœÀ Œÿ√ √À‰«¡ «” —œ«œ  ›«’Ì· «·„⁄«„·…");
            }
        }
    }
}