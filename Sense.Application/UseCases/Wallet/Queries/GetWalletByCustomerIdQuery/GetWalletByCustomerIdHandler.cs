using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.DTOs.WalletDTOs;
using Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsByBranchIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Wallet.Queries.GetWalletByCustomerIdQuery
{
    public class GetWalletByCustomerIdHandler : IRequestHandler<GetWalletByCustomerIdQuery, ResponseResult<WalletDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetWalletByCustomerIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<WalletDto>> Handle(GetWalletByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if(customer is null)
                return ResponseResult<WalletDto>.GetResult(ResultCodeStatus.NotFound, "The User Not Found!!");


            var wallet = await _repositoryManager.Wallet.GetWalletsByCustomerId(customer.Id);
            if(wallet is null)
            {
                var newWallet = new WalletTbl
                {
                    CustomerId = customer.Id,
                    Balance = 0,
                    CreatedAt = DateTime.UtcNow
                };
                _repositoryManager.Wallet.CreateWallet(newWallet);
                await _repositoryManager.SaveAsync();
                var newDto = _mapper.Map<WalletDto>(newWallet);
                return ResponseResult<WalletDto>.GetResult(ResultCodeStatus.Success, newDto, "Wallet created and retrieved successfully.");

            }
            var dto = _mapper.Map<WalletDto>(wallet);
            return ResponseResult<WalletDto>.GetResult(ResultCodeStatus.Success, dto, "Wallet retrieved successfully.");

        }
    }
}
