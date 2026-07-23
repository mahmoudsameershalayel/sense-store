using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Commands.UpdateStatementStatusCommand
{
    public class UpdateStatementStatusHandler : IRequestHandler<UpdateStatementStatusCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public UpdateStatementStatusHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateStatementStatusCommand request, CancellationToken cancellationToken)
        {
            var statement = await _repositoryManager.Statement.GetStatementByIdAsync(request.StatementId);
            if (statement is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The statement with id : {request.StatementId} Not Found!!");

            statement.IsActive = !statement.IsActive;

            _repositoryManager.Statement.UpdateStatement(statement);
            var result = await _repositoryManager.SaveAsync();
            if (result != 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The statement with id : {statement.Id} Updated successfully");

            return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The Operation Failed!!");
        }
    }
}
