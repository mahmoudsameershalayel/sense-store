using Sense.Domain.Enums;
using Sense.Application.DTOs.PointsDTOs;
using Sense.Application.UseCases.Points.Commands.RedeemPointsCommand;
using Sense.Application.UseCases.Points.Queries.GetPointsInfoQuery;
using Sense.Application.UseCases.Points.Queries.GetPointsTransactionQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Controllers
{
    [Authorize(Roles = "Customer")]
    public class PointsController : Controller
    {
        private readonly IMediator _mediator;
        public PointsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> InfoOrder(int orderId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pointsInfo = await _mediator.Send(new GetPointsInfoQuery { CurrentUserId = userId, OrderId = orderId });

            if (pointsInfo == null)
                return Json(new { result = new { code = 404, message = "معلومات النقاط غير متوفرة" } });

            // Add server-side eligibility validation
            var isEligible = pointsInfo.Data.CanRedeem && !pointsInfo.Data.AlreadyRedeemed;

            return Json(new { 
                result = new { code = 200 }, 
                data = pointsInfo,
                isEligible = isEligible
            });
        }

        [HttpGet]
        public async Task<IActionResult> InfoMaintenance(int maintenanceId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pointsInfo = await _mediator.Send(new GetPointsInfoQuery { CurrentUserId = userId, MaintenanceRecordId = maintenanceId });

            if (pointsInfo == null)
                return Json(new { result = new { code = 404, message = "Points info not found" } });

            return Json(new { result = new { code = 200 }, data = pointsInfo });
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionByOrder(int orderId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _mediator.Send(new GetPointsTransactionQuery { CurrentUserId = userId, OrderId = orderId });

            if (transaction.Result.Code != ResultCodeStatus.Success)
                return Json(new { result = new { code = 404, message = transaction.Result.Message } });

            return Json(new { 
                result = new { code = 200 }, 
                data = new { 
                    orderId = orderId,
                    amountDeducted = transaction.Data.AmountDeducted,
                    pointsRedeemed = transaction.Data.PointsRedeemed,
                    transactionDate = transaction.Data.CreatedAt
                } 
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionByMaintenance(int maintenanceId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _mediator.Send(new GetPointsTransactionQuery { CurrentUserId = userId, MaintenanceRecordId = maintenanceId });

            if (transaction.Result.Code != ResultCodeStatus.Success)
                return Json(new { result = new { code = 404, message = transaction.Result.Message } });

            return Json(new { 
                result = new { code = 200 }, 
                data = new { 
                    maintenanceRecordId = maintenanceId,
                    amountDeducted = transaction.Data.AmountDeducted,
                    pointsRedeemed = transaction.Data.PointsRedeemed,
                    transactionDate = transaction.Data.CreatedAt
                } 
            });
        }

        [HttpPost]
        public async Task<IActionResult> Redeem([FromBody] RedeemPointsDto redeemData)
        {
            if (redeemData == null || (redeemData.OrderId <= 0 && redeemData.MaintenanceRecordId <= 0))
                return Json(new { result = new { code = 400, message = "بيانات غير صحيحة" } });

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            redeemData.CurrentUserId = userId;
            var redemptionResult = await _mediator.Send(new RedeemPointsCommand { Dto = redeemData });

            if (redemptionResult.Result.Code != ResultCodeStatus.Success)
                return Json(new { result = new { code = 400, message = redemptionResult.Result.Message } });

            return Json(new
            {
                result = new { code = 200 },
                data = new
                {
                    amountDeducted = redemptionResult.Data.AmountDeducted,
                    remainingPoints = redemptionResult.Data.RemainingPoints
                }
            });
        }
    }
}
