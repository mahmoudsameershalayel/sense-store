using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.ReceiveAppointmentCommand
{
    public class ReceiveAppointmentHandler : IRequestHandler<ReceiveAppointmentCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ReceiveAppointmentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(ReceiveAppointmentCommand request, CancellationToken cancellationToken)
        {
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if (supervisor is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Supervisor Not Found!!");

            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(request.AppointmentId);
            if (appointment is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Appointment Not Found!!");

             if(appointment.Status != AppointmentStatus.Scheduled)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"لا يمكن إستلام السيارة إلا في حالة الحجوزات المجدولة!!");

            appointment.Status = AppointmentStatus.Received;
            _repositoryManager.Appointment.UpdateAppointment(appointment);

            var maintenanceRecord = new MaintenanceRecordTbl
            {
                StartDate = DateTime.Now,
                AppointmentId = appointment.Id,
                SupervisorId = supervisor.Id,
                Status = MaintenanceStatus.UnderMaintenance
            };

            _repositoryManager.MaintenanceRecord.CreateMaintenanceRecord(maintenanceRecord);
            try
            {
                await _repositoryManager.SaveAsync();
            }
            catch (DbUpdateException dbEx)
            {
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Failed,
                    $"DbUpdateException: {dbEx.Message} - Inner: {dbEx.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Failed,
                    $"Exception: {ex.Message} - Inner: {ex.InnerException?.Message}");
            }
           

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Appointment Received successfully");

        }
    }
}
