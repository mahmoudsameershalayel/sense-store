using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.WalletDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.TransactionDTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }
        public string? Details { get; set; }
        public string CreatedAtDate { get; set; }
        public string CreatedAtTime { get; set; }

        public CustomerDto Customer { get; set; }

        public WalletDto Wallet { get; set; }
    }
}
