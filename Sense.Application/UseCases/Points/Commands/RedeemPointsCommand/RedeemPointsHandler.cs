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

namespace Sense.Application.UseCases.Points.Commands.RedeemPointsCommand
{
    public class RedeemPointsHandler : IRequestHandler<RedeemPointsCommand, ResponseResult<RedeemPointsResultDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;

        public RedeemPointsHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<RedeemPointsResultDto>> Handle(RedeemPointsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get center settings for points configuration
                var centerSettings = await _repositoryManager.CenterSetting.GetCenterSettingAsync();
                if (centerSettings == null)
                {
                    return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.NotFound, 
                        "≈⁄œ«œ«  «·‰Ÿ«„ €Ì— „ÊÃÊœ…!");
                }

                // Get customer information
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.Dto.CurrentUserId);
                if (customer == null)
                {
                    return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.NotFound, 
                        "«·⁄„Ì· €Ì— „ÊÃÊœ!");
                }

                var user = await _userManager.FindByIdAsync(customer.ApplicationUserId);
                if (user == null)
                {
                    return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.NotFound, 
                        "«·„” Œœ„ €Ì— „ÊÃÊœ!");
                }

                // Validate points amount
                if (request.Dto.PointsToRedeem < centerSettings.MinRedeemPoints)
                {
                    return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.BadRequest, 
                        $"«·Õœ «·√œ‰Ï ·«” —œ«œ «·‰ﬁ«ÿ ÂÊ {centerSettings.MinRedeemPoints} ‰ﬁÿ…");
                }

                if (request.Dto.PointsToRedeem > centerSettings.MaxRedeemPoints)
                {
                    return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.BadRequest, 
                        $"«·Õœ «·√ﬁ’Ï ·«” —œ«œ «·‰ﬁ«ÿ ÂÊ {centerSettings.MaxRedeemPoints} ‰ﬁÿ…");
                }

                // Check if user has sufficient points
                var currentPoints = user.MyPoints ?? 0;
                if (currentPoints < request.Dto.PointsToRedeem)
                {
                    return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.BadRequest, 
                        $"—’Ìœ «·‰ﬁ«ÿ €Ì— ﬂ«›Ì. «·—’Ìœ «·Õ«·Ì: {currentPoints} ‰ﬁÿ…");
                }

                // Check if points were already redeemed for this order or maintenance record
                if (request.Dto.OrderId.HasValue)
                {
                    var existingOrderRedemption = await _repositoryManager.PointsTransaction.GetPointsTransactionByOrderIdAsync(request.Dto.OrderId.Value);
                    if (existingOrderRedemption != null)
                    {
                        return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.BadRequest, 
                            " „ «” —œ«œ «·‰ﬁ«ÿ „”»ﬁ« ·Â–« «·ÿ·»");
                    }
                }

                if (request.Dto.MaintenanceRecordId.HasValue)
                {
                    var existingMaintenanceRedemption = await _repositoryManager.PointsTransaction.GetPointsTransactionByMaintenanceRecordIdAsync(request.Dto.MaintenanceRecordId.Value);
                    if (existingMaintenanceRedemption != null)
                    {
                        return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.BadRequest, 
                            " „ «” —œ«œ «·‰ﬁ«ÿ „”»ﬁ« ·”Ã· «·’Ì«‰… Â–«");
                    }
                }

                // Calculate amount to deduct
                decimal amountDeducted = request.Dto.PointsToRedeem * centerSettings.PointsToSARRate;

                // Create points transaction record
                var pointsTransaction = new PointsTransactionTbl
                {
                    CustomerId = customer.Id,
                    PointsRedeemed = request.Dto.PointsToRedeem,
                    AmountDeducted = amountDeducted,
                    PointsToSARRate = centerSettings.PointsToSARRate,
                    OrderId = request.Dto.OrderId,
                    MaintenanceRecordId = request.Dto.MaintenanceRecordId,
                    CreatedAt = DateTime.UtcNow,
                    Details = request.Dto.OrderId.HasValue 
                        ? $"«” —œ«œ ‰ﬁ«ÿ ··ÿ·» —ﬁ„ {request.Dto.OrderId}" 
                        : $"«” —œ«œ ‰ﬁ«ÿ ·”Ã· «·’Ì«‰… —ﬁ„ {request.Dto.MaintenanceRecordId}"
                };

                // Update user points
                user.MyPoints = currentPoints - request.Dto.PointsToRedeem;
                await _userManager.UpdateAsync(user);

                // Save points transaction
                _repositoryManager.PointsTransaction.CreatePointsTransaction(pointsTransaction);
                await _repositoryManager.SaveAsync();

                var result = new RedeemPointsResultDto
                {
                    Success = true,
                    Message = $" „ «” —œ«œ {request.Dto.PointsToRedeem} ‰ﬁÿ… »‰Ã«Õ",
                    AmountDeducted = amountDeducted,
                    PointsRedeemed = request.Dto.PointsToRedeem,
                    RemainingPoints = user.MyPoints.Value,
                    PointsToSARRate = centerSettings.PointsToSARRate
                };

                return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.Success, result, 
                    " „ «” —œ«œ «·‰ﬁ«ÿ »‰Ã«Õ");
            }
            catch (Exception ex)
            {
                return ResponseResult<RedeemPointsResultDto>.GetResult(ResultCodeStatus.Failed, 
                    "ÕœÀ Œÿ√ √À‰«¡ «” —œ«œ «·‰ﬁ«ÿ");
            }
        }
    }
}