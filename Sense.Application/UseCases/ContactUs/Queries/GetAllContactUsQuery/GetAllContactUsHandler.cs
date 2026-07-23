using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Queries.GetAllContactUsQuery
{
    public class GetAllContactUsHandler : IRequestHandler<GetAllContactUsQuery, ResponseResult<IEnumerable<ContactFormTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllContactUsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ContactFormTbl>>> Handle(GetAllContactUsQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.ContactUs.GetAllContactsAsync();
            return ResponseResult<IEnumerable<ContactFormTbl>>.GetResult(ResultCodeStatus.Success, items, "The data reterived successfully.");

        }
    }
}
