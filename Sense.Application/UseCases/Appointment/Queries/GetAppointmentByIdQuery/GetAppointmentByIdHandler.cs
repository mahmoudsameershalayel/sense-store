using Sense.Application.RequestFeatures;
using Sense.Application;
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
using Microsoft.AspNetCore.Identity;
using Sense.Domain.DBEntities;

namespace Sense.Application.UseCases.Appointment.Queries.GetAppointmentByIdQuery
{
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdQuery, ResponseResult<AppointmentDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;
        public GetAppointmentByIdHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AppointmentDto>> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(request.AppointmentId); ;
            if (appointment is null)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.NotFound, "The Appointment Not Found!!");

            var dto = _mapper.Map<AppointmentDto>(appointment);

            var user = await _userManager.FindByIdAsync(request.CurrentUserId);
            if(user is null)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Failed, "You can not access to this appointment.");

            switch (user.UserType)
            {
                case UserType.Administrator:
                    return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
                    break;
                case UserType.Customer:
                    var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
                    if (customer is null)
                        return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.NotFound, "The Customer Not Found!!");
                    if (appointment.CustomerId == customer.Id)
                        return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
                    break;
                case UserType.Supervisor:
                    var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
                    if (supervisor is null)
                        return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.NotFound, "The Supervisor Not Found!!");
                    if (appointment.SupervisorId == supervisor.Id)
                        return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
                    break;

            }
            return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Failed, "You can not access to this appointment.");



        }
    }
}
