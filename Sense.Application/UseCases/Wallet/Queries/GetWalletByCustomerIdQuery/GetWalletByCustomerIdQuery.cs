using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Wallet.Queries.GetWalletByCustomerIdQuery
{
    public class GetWalletByCustomerIdQuery : IRequest<ResponseResult<WalletDto>>
    {
        public string CurrentUserId { get; set; }
    }
}