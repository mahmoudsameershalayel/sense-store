using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.UseCases.Brand.Commands.CreateBrandCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Invoice.Commands.CreateInvoiceCommand
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, ResponseResult<InvoiceDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateInvoiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<InvoiceDto>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var maintenanceRecord = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByIdAsync(request.Dto.MaintenanceRecordId);
            if(maintenanceRecord is null)           
                return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.NotFound, "The Maintenance Record Not Found!!");
            if(maintenanceRecord.Appointment.Status != AppointmentStatus.Received)
                return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.BadRequest, "لا يمكنك إضافة فاتورة إلا إذا كانت حالة الحجز 'تم الإستلام'.");
           
            var invoice = await _repositoryManager.Invoice.GetInvoiceByIdAsync(request.Dto.InvoiceNo);
            if(invoice is not null)
                return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.BadRequest, "الفاتورة موجودة مسبقا!!");


            var entity = _mapper.Map<InvoiceTbl>(request.Dto);
            entity.CreatedAt = DateTime.UtcNow;
            _repositoryManager.Invoice.CreateInvoice(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<InvoiceDto>(entity);
            return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.Created, dto, $"The Invoice with NO. : {entity.InvoiceNo} created successfully");
        }
    }
}
