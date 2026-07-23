using Sense.Domain.Enums;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.InvoiceDTOs
{
    public class InvoiceDto
    {
        public long InvoiceNo { get; set; }
        public decimal InvoiceAmount { get; set; }
        public MaintenanceRecordDto? MaintenanceRecord { get; set; }
        public string? InvoiceType { get; set; }
        public string? CreatedAtDate { get; set; }
        public string? CreatedAtTime { get; set; }
        public string? InvoiceTypeAR
        {
            get
            {
                if (Enum.TryParse<InvoiceType>(InvoiceType, out var enumValue))
                    return enumValue.GetDisplayName();

                return "‰Ê⁄ €Ì— „⁄—Ê›";
            }
        }
    }

}
