using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery
{
    public class LoadAppointmentsQuery : IRequest<ResponseResult<IQueryable<AppointmentTbl>>>
    {
        public string? CurrentUserId { get; set; }

    }
}