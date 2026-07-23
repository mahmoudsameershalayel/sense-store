using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "مدى")]
        Mada = 1,
        [Display(Name = "محفظة")]
        Wallet = 2,
        [Display(Name = "الدفع عند الإستلام")]
        CashOnDeliver = 3
    }
}
