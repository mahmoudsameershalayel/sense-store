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
    public class CreatePartnerInquiryCommand : IRequest<ResponseResult<PartnerInquiryTbl>>
    {
        public PartnerInquiryTbl? Inquiry { get; set; }
    }
}
