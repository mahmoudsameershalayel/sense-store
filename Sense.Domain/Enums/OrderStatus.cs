using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "بإنتظار المراجعة")]
        Pending = 1,
        [Display(Name = "قيد التجهيز")]
        Preparing = 2,
        [Display(Name = "تم التجهيز")]
        Prepared = 3,
        [Display(Name = "في الطريق")]
        OutForDelivery = 4,
        [Display(Name = "تم التوصيل")]
        Deliverd = 5,
        [Display(Name = "لم يتم التوصيل")]
        NotDeliverd = 7,
        [Display(Name = "مرفوض")]
        Rejected = 6,
    }
}
