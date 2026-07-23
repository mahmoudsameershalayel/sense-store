using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.CompleteAppointmentCommand
{
    public class CompleteAppointmentHandler : IRequestHandler<CompleteAppointmentCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CompleteAppointmentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(CompleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(request.AppointmentId);
            var maintenanceRecord = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByAppointmentIdAsync(request.AppointmentId);
            if (appointment is null || maintenanceRecord is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"You can not complete the maintenance record because it is not found!!");


            maintenanceRecord.Status = MaintenanceStatus.Completed;
            appointment.Status = AppointmentStatus.Completed;
            _repositoryManager.MaintenanceRecord.UpdateMaintenanceRecord(maintenanceRecord);
            _repositoryManager.Appointment.UpdateAppointment(appointment);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"Error occured while saving entity!!");

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Appointment Completed successfully");

        }
    }
}