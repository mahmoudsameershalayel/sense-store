using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsBySupervisorIdQuery
{
    public class GetAllAppointmentsBySupervisorIdQuery : IRequest<ResponseResult<PagedList<AppointmentDto>>>
    {
        public string? CurrentUserId { get; set; }
        public AppointmentParameters AppointmentParameters { get; set; }

    }
}