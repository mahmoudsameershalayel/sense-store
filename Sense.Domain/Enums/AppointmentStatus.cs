using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum AppointmentStatus
    {
        [Display(Name = "قيد الإنتظار")]
        Pending = 1,
        [Display(Name = "مجدول")]
        Scheduled = 2,
        [Display(Name = "تم الإستلام")]
        Received = 3,
        [Display(Name = "مكتمل")]
        Completed = 4,
        [Display(Name = "ملغي")]
        Canceled = 5,
        [Display(Name = "مرفوض")]
        Rejected = 6,
        [Display(Name = "تمت الموافقة")]
        Accepted = 7,
    }
}
