using Sense.Application;
using Sense.Domain.Enums;
using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.StatementDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Commands.CreateStatementCommand
{
    public class CreateStatementHandler : IRequestHandler<CreateStatementCommand, ResponseResult<StatementDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateStatementHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<StatementDto>> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StatementTbl>(request.Dto);
            _repositoryManager.Statement.CreateStatement(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<StatementDto>(entity);
            return ResponseResult<StatementDto>.GetResult(ResultCodeStatus.Created, dto, $"The Statement with Id : {entity.Id} created successfully");
        }
    }
}
