using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.PartnerInquiry.Queries.GetAllPartnerInquiriesQuery
{
    public class GetAllPartnerInquiriesQuery : IRequest<ResponseResult<IEnumerable<PartnerInquiryTbl>>>
    {
    }
}
