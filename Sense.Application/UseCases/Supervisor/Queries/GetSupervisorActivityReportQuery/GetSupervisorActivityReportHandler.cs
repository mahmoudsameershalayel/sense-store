using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Queries.GetSupervisorActivityReportQuery
{
    public class GetSupervisorActivityReportHandler : IRequestHandler<GetSupervisorActivityReportQuery, ResponseResult<SupervisorReportDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetSupervisorActivityReportHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        private static string GetArabicActivityType(ActivityType type)
        {
            return type switch
            {
                ActivityType.ApprovedMaintenance => "الموافقة على الصيانة",
                ActivityType.CreatedInvoice => "إنشاء فاتورة",
                ActivityType.RejectedMaintenance => "رفض الصيانة",
                ActivityType.RejecteAppointment => "رفض الإستلام",
                ActivityType.UpdatedAppointment => "تحديث الموعد",
                ActivityType.ReceiveAppointment => "إستلام السيارة",
                ActivityType.CompleteAppointment => "إكمال الحجز",
                ActivityType.CompleteMaintenanceRecord => "إكمال الصيانة",
                _ => "نشاط غير معروف"
            };
        }

        public async Task<ResponseResult<SupervisorReportDto>> Handle(GetSupervisorActivityReportQuery request, CancellationToken cancellationToken)
        {
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.SupervisorId);
            if (supervisor is null)
                return ResponseResult<SupervisorReportDto>.GetResult(ResultCodeStatus.NotFound, "The User Not Found.");


            var recentLogs = supervisor.ActivityLogs.OrderByDescending(l => l.CreatedAt)
                                                    .Take(10)
                                                    .Select(l => new SupervisorRecentLogDto
                                                    {
                                                        Date = l.CreatedAt,
                                                        Type = l.ActivityType.ToString(),
                                                        Description = l.Description
                                                    })
                                                    .ToList();

            var activityStats = supervisor.ActivityLogs.GroupBy(l => l.ActivityType)
                                                       .ToDictionary(g => GetArabicActivityType(g.Key ?? 0), g => g.Count());

            var model = new SupervisorReportDto
            {
                SupervisorName = supervisor.ApplicationUser?.UserName ?? "Unknown",
                BranchName = supervisor.Branch?.BranchName ?? "N/A",
                TotalAppointments = supervisor.Appointments.Count,
                TotalMaintenanceRecords = supervisor.MaintenanceRecords.Count,
                RecentLogs = recentLogs   ,
                ActivityLogStats = activityStats
            };

            return ResponseResult<SupervisorReportDto>.GetResult(ResultCodeStatus.Success, model, "The data reterived successfully.");
        }
    }
}
