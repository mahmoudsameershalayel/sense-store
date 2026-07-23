using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.TransactionDTOs
{
    public class TransactionForCreateDto
    {
        public decimal Amount { get; set; }
        public TransactionType? TransactionType { get; set; }
        public string? Details { get; set; }
        public DateTime CraetedAt { get; set; }

        public int CustomerId { get; set; }

    }
}
