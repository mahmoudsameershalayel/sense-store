using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.PartnerInquiry.Commands.CreatePartnerInquiryCommand
{
    public class CreatePartnerInquiryHandler : IRequestHandler<CreatePartnerInquiryCommand, ResponseResult<PartnerInquiryTbl>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public CreatePartnerInquiryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<PartnerInquiryTbl>> Handle(CreatePartnerInquiryCommand request, CancellationToken cancellationToken)
        {
            _repositoryManager.PartnerInquiry.CreatePartnerInquiry(request.Inquiry);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<PartnerInquiryTbl>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            return ResponseResult<PartnerInquiryTbl>.GetResult(ResultCodeStatus.Created, request.Inquiry, "تم إرسال طلبك بنجاح.");
        }
    }
}
