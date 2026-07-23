using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.AssignAppointmentCommand
{
    public class AssignAppointmentHandler : IRequestHandler<AssignAppointmentCommand, ResponseResult<AppointmentDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AssignAppointmentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AppointmentDto>> Handle(AssignAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(request.Dto.AppointmentId);
            if (appointment is null)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.NotFound, $"The Appointment Not Found!!");

            if (appointment.Status != AppointmentStatus.Pending)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.BadRequest, $"لا يمكن تعيين الحجوزات إلا في حالة الحجوزات قيد الإنتظار!!");

            appointment.BranchId = request.Dto.BranchId;
            appointment.SupervisorId = request.Dto.SupervisorId;
            appointment.ScheduledDate = request.Dto.ScheduledDate;
            appointment.Status = AppointmentStatus.Scheduled;
            _repositoryManager.Appointment.UpdateAppointment(appointment);


            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<AppointmentDto>(appointment);

            return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Success, dto, $"The Appointment Assigned successfully");

        }
    }
}
