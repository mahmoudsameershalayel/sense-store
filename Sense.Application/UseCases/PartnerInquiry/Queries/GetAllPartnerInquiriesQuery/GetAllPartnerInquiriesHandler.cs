using Sense.Application;
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
    public class GetAllPartnerInquiriesHandler : IRequestHandler<GetAllPartnerInquiriesQuery, ResponseResult<IEnumerable<PartnerInquiryTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public GetAllPartnerInquiriesHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IEnumerable<PartnerInquiryTbl>>> Handle(GetAllPartnerInquiriesQuery request, CancellationToken cancellationToken)
        {
            var items = await _repositoryManager.PartnerInquiry.GetAllPartnerInquiriesAsync();
            return ResponseResult<IEnumerable<PartnerInquiryTbl>>.GetResult(ResultCodeStatus.Success, items, "The data reterived successfully.");
        }
    }
}
