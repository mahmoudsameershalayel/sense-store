using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.TransactionDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Wallet.Commands.ChargeWalletCommand
{
    public class ChargeWalletCommand : IRequest<ResponseResult<bool>>
    {
        public TransactionForCreateDto? Dto { get; set; }
    }
}
