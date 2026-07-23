using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.ReceiveAppointmentCommand
{
    public class ReceiveAppointmentCommand : IRequest<ResponseResult<bool>>
    {
        public string CurrentUserId { get; set; }
        public int AppointmentId { get; set; }
    }
}
