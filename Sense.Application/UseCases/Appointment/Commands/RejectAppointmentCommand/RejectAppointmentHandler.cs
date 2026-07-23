using Sense.Application.DomainEntities;
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

namespace Sense.Application.UseCases.Appointment.Commands.RejectAppointmentCommand
{
    public class RejectAppointmentHandler : IRequestHandler<RejectAppointmentCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public RejectAppointmentHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(RejectAppointmentCommand request, CancellationToken cancellationToken)
        {
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if (supervisor is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Supervisor Not Found!!");

            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(request.Dto.AppointmentId);
            if (appointment is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound,false, $"The Appointment Not Found!!");

            if (appointment.Status != AppointmentStatus.Scheduled)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"·« Ì„ﬂ‰ —›÷ ≈” ·«„ «·”Ì«—… ≈·« ›Ì Õ«·… «·ÕÃÊ“«  «·„ÃœÊ·…!!");


            appointment.Status = AppointmentStatus.Rejected;   
            appointment.RejectReason = request.Dto.RejectReason;
            _repositoryManager.Appointment.UpdateAppointment(appointment);


            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest,false , $"Error occured while saving entity!!");


            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Appointment Canceled successfully");

        }
    }
}
