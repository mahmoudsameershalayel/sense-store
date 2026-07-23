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

namespace Sense.Application.UseCases.Statement.Queries.GetActiveStatementsQuery
{
    public class GetActiveStatementsHandler : IRequestHandler<GetActiveStatementsQuery, ResponseResult<IEnumerable<StatementDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetActiveStatementsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<StatementDto>>> Handle(GetActiveStatementsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repositoryManager.Statement.GetActiveStatementsAsync();
            var dtos = _mapper.Map<List<StatementDto>>(items);
            return ResponseResult<IEnumerable<StatementDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");
        }
    }
}
