using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.InvoiceDTOs
{
    public class InvoiceForUpdateDto
    {
        public long InvoiceNo { get; set; }
        public decimal InvoiceAmount { get; set; }
        public InvoiceType? InvoiceType { get; set; }
    }
}