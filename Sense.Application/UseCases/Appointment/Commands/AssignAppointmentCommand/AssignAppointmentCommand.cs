using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.AssignAppointmentCommand
{
    public class AssignAppointmentCommand : IRequest<ResponseResult<AppointmentDto>>
    {
        public AssignAppointmentDto Dto { get; set; }
    }
}
