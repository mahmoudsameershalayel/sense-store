using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum InvoiceType
    {
        [Display(Name = "فاتورة قطع غيار")]
        SparePartInvoice = 1,
        [Display(Name = "فاتورة أجرة عمل")]
        LaborCostInvoice = 2,
        [Display(Name = "فاتورة طلب متجر")]
        StoreOrderInvoice = 3,
    }
}
