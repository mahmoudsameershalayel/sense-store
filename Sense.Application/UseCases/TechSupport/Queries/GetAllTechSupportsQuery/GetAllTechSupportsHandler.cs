using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.DTOs.TechSupportDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.TechSupport.Queries.GetAllTechSupportsQuery
{
    public class GetAllTechSupportsHandler : IRequestHandler<GetAllTechSupportsQuery, ResponseResult<IEnumerable<TechSupportDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllTechSupportsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<TechSupportDto>>> Handle(GetAllTechSupportsQuery request, CancellationToken cancellationToken)
        {
            var techSupports = await _repositoryManager.TechSupport.GetAllTechSupportsAsync();
            if (!string.IsNullOrEmpty(request.Name))
                techSupports = techSupports.Where(i => i.ApplicationUser.FirstName.Contains(request.Name) || i.ApplicationUser.LastName.Contains(request.Name) || i.ApplicationUser.UserName.Contains(request.Name)).ToList();

            var dtos = _mapper.Map<List<TechSupportDto>>(techSupports);
            return ResponseResult<IEnumerable<TechSupportDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");
        }
    }
}
