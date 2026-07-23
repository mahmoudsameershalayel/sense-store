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

namespace Sense.Application.UseCases.Points.Queries.GetPointsInfoQuery
{
    public class GetPointsInfoHandler : IRequestHandler<GetPointsInfoQuery, ResponseResult<PointsInfoDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public GetPointsInfoHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }

        public async Task<ResponseResult<PointsInfoDto>> Handle(GetPointsInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Get center settings for points configuration
                var centerSettings = await _repositoryManager.CenterSetting.GetCenterSettingAsync();
                if (centerSettings == null)
                {
                    return ResponseResult<PointsInfoDto>.GetResult(ResultCodeStatus.NotFound, 
                        "≈⁄œ«œ«  «·‰Ÿ«„ €Ì— „ÊÃÊœ…!");
                }

                // Get customer information
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
                if (customer == null)
                {
                    return ResponseResult<PointsInfoDto>.GetResult(ResultCodeStatus.NotFound, 
                        "«·⁄„Ì· €Ì— „ÊÃÊœ!");
                }

                var user = await _userManager.FindByIdAsync(customer.ApplicationUserId);
                if (user == null)
                {
                    return ResponseResult<PointsInfoDto>.GetResult(ResultCodeStatus.NotFound, 
                        "«·„” Œœ„ €Ì— „ÊÃÊœ!");
                }

                // Check if points were already redeemed for this order or maintenance record
                bool alreadyRedeemed = false;
                if (request.OrderId.HasValue)
                {
                    var existingOrderRedemption = await _repositoryManager.PointsTransaction.GetPointsTransactionByOrderIdAsync(request.OrderId.Value);
                    alreadyRedeemed = existingOrderRedemption != null;
                }
                
                if (request.MaintenanceRecordId.HasValue)
                {
                    var existingMaintenanceRedemption = await _repositoryManager.PointsTransaction.GetPointsTransactionByMaintenanceRecordIdAsync(request.MaintenanceRecordId.Value);
                    alreadyRedeemed = existingMaintenanceRedemption != null;
                }

                var currentPoints = user.MyPoints ?? 0;
                var canRedeem = currentPoints >= centerSettings.MinRedeemPoints && !alreadyRedeemed;

                var pointsInfo = new PointsInfoDto
                {
                    CurrentPoints = currentPoints,
                    PointsToSARRate = centerSettings.PointsToSARRate,
                    MinRedeemPoints = centerSettings.MinRedeemPoints,
                    MaxRedeemPoints = centerSettings.MaxRedeemPoints,
                    CanRedeem = canRedeem,
                    AlreadyRedeemed = alreadyRedeemed,
                    CustomerName = $"{user.FirstName} {user.LastName}"
                };

                return ResponseResult<PointsInfoDto>.GetResult(ResultCodeStatus.Success, pointsInfo, 
                    " „ «” —œ«œ „⁄·Ê„«  «·‰ﬁ«ÿ »‰Ã«Õ");
            }
            catch (Exception ex)
            {
                return ResponseResult<PointsInfoDto>.GetResult(ResultCodeStatus.Failed, 
                    "ÕœÀ Œÿ√ √À‰«¡ «” —œ«œ „⁄·Ê„«  «·‰ﬁ«ÿ");
            }
        }
    }
}