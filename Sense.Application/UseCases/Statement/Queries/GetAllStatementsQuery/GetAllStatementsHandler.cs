using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.StatementDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Queries.GetAllStatementsQuery
{
    public class GetAllStatementsHandler : IRequestHandler<GetAllStatementsQuery, ResponseResult<IEnumerable<StatementDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllStatementsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<StatementDto>>> Handle(GetAllStatementsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repositoryManager.Statement.GetAllStatementsAsync();
            var dtos = _mapper.Map<List<StatementDto>>(items);
            return ResponseResult<IEnumerable<StatementDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");
        }
    }
}
