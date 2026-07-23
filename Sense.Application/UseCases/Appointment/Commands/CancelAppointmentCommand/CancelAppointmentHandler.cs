using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.CancelAppointmentCommand
{
    public class CancelAppointmentHandler : IRequestHandler<CancelAppointmentCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CancelAppointmentHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.CurrentUserId);
            if (user is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The User Not Found!!");
            if(user.UserType != UserType.Administrator)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Forbiden, false, $"You hav not premission to cancel appointment!!");


            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(request.AppointmentId);
            if (appointment is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Appointment Not Found!!");

            if (appointment.Status != AppointmentStatus.Pending)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"لا يمكن إلغاء الحجوزات إلا في حالة الحجوزات قيد الإنتظار!!");


            appointment.Status = AppointmentStatus.Canceled;
            _repositoryManager.Appointment.UpdateAppointment(appointment);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"Error occured while saving entity!!");

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Appointment Received successfully");

        }
    }
}
