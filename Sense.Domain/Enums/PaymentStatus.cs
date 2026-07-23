using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum PaymentStatus
    {
        [Display(Name = "معلق")]
        Pending = 1,
        [Display(Name = "تم الدفع")]
        Completed = 2,
        [Display(Name = "فشلت العملية")]
        Failed = 3,
    }
}
