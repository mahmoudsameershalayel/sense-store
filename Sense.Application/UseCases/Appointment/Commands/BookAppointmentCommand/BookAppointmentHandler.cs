using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.BannerDTOs;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Appointment.Commands.BookAppointmentCommand
{
    public class BookAppointmentHandler : IRequestHandler<BookAppointmentCommand, ResponseResult<AppointmentDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public BookAppointmentHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AppointmentDto>> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");
            var allAppointments = await _repositoryManager.Appointment.GetAllAppointmentsAsync();
            var existSamePending = allAppointments.Where(x => x.Customer.ApplicationUserId.Equals(customer.ApplicationUserId) && x.ModelYear.Equals(request.Dto.ModelYear) && x.Status == AppointmentStatus.Pending && x.ServiceId == request.Dto.ServiceId && x.BrandId == request.Dto.BrandId && x.ModelId == request.Dto.ModelId).FirstOrDefault();
            if (existSamePending is not null)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.BadRequest, $"لديك حجز قيد الانتظار بنفس بيانات هذا الحجز.\r\nيرجى مراجعة حجوزاتك الحالية قبل إنشاء حجز جديد مشابه.!!");

            var appointment = _mapper.Map<AppointmentTbl>(request.Dto);
            appointment.CustomerId = customer.Id;
            appointment.Status = AppointmentStatus.Pending;
            _repositoryManager.Appointment.CreateAppointment(appointment);


            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var createdAppointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(appointment.Id);
            var dto = _mapper.Map<AppointmentDto>(createdAppointment);

            return ResponseResult<AppointmentDto>.GetResult(ResultCodeStatus.Success, dto, $"The Appointment Booked successfully");

        }
    }
}
