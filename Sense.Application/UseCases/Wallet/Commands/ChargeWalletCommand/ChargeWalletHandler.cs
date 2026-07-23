using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.DTOs.TransactionDTOs;
using Sense.Application.UseCases.Service.Commands.CreateServiceCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Wallet.Commands.ChargeWalletCommand
{
    public class ChargeWalletHandler : IRequestHandler<ChargeWalletCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ChargeWalletHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(ChargeWalletCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByIdAsync(request.Dto.CustomerId);
            if (customer is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "Customer not found!!");


            var wallet = await _repositoryManager.Wallet.GetWalletsByCustomerId(request.Dto.CustomerId);
            if (wallet is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "Wallet not found!!");

            wallet.Balance += (double)request.Dto.Amount;
            wallet.UpdatedAt = DateTime.UtcNow;

            var transaction = new TransactionTbl
            {
                Amount = request.Dto.Amount,
                TransactionType = TransactionType.Charge,
                WalletId = wallet.Id,
                CustomerId = customer.Id,
                Details = request.Dto.Details
            };

            _repositoryManager.Transaction.CreateTransaction(transaction);
            await _repositoryManager.SaveAsync();

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "Wallet Charged Successfully!!");

        }
    }
}
