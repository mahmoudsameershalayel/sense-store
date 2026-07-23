using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class InvoiceTbl
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InvoiceNo { get; set; }
        public decimal InvoiceAmount { get; set; }
        public InvoiceType? InvoiceType { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int? MaintenanceRecordId { get; set; }
        public MaintenanceRecordTbl? MaintenanceRecord { get; set; }

        public int? OrderId { get; set; }
        public OrderTbl? Order { get; set; }
     
    }
}
