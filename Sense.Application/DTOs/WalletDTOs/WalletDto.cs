using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.WalletDTOs
{
    public class WalletDto
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string? CreatedAtDate { get; set; }
        public string? CreatedAtTime { get; set; }

        public CustomerDto? Customer { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

    }
}
