using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.MaintenanceRecordDTOs
{
    public class CompleteMaintenanceRecordDto
    {
        public long InvoiceNo { get; set; }
        public decimal LaborCost { get; set; }
    }
}
