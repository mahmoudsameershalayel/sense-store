using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Statement.Commands.DeleteStatementCommand
{
    public class DeleteStatementHandler : IRequestHandler<DeleteStatementCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DeleteStatementHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteStatementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Statement.GetStatementByIdAsync(request.StatementId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The statement with Id : {request.StatementId} not exist in the database!!");

            entity.IsDeleted = true;

            _repositoryManager.Statement.UpdateStatement(entity);
            await _repositoryManager.SaveAsync();

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Statement with Id : {request.StatementId} deleted successfully");
        }
    }
}
