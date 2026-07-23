using Sense.Application.RequestFeatures;
using Sense.Application.DTOs.AppointmentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsForStatisticsQuery
{
    public class GetAllAppointmentsForStatisticsQuery : IRequest<ResponseResult<IEnumerable<AppointmentDto>>>
    {
    }
}