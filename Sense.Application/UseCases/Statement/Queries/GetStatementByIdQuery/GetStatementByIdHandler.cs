using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.StatementDTOs;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Queries.GetStatementByIdQuery
{
    public class GetStatementByIdHandler : IRequestHandler<GetStatementByIdQuery, ResponseResult<StatementDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetStatementByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<StatementDto>> Handle(GetStatementByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Statement.GetStatementByIdAsync(request.StatementId);
            if (entity is null)
                return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.NotFound, $"The Statement with Id : {request.StatementId} not exist in the database!!");

            var dto = _mapper.Map<StatementDto>(entity);
            return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
