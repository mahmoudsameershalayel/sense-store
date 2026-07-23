using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.BannerDTOs;
using MediatR;


namespace Sense.Application.UseCases.Appointment.Commands.BookAppointmentCommand
{
	public class BookAppointmentCommand : IRequest<ResponseResult<AppointmentDto>>
	{
        public required string CurrentUserId { get; set; }
        public AppointmentForCreateDto Dto { get; set; }
    }
}
