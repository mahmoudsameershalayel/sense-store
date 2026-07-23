using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{
    public enum ProductStatus
    {
        [Display(Name = "مسودة")]
        Draft = 1,
        [Display(Name = "بإنتظار المراجعة")]
        PendingReview = 2,
        [Display(Name = "مقبول")]
        Approved = 3,
        [Display(Name = "مرفوض")]
        Rejected = 4,
        [Display(Name = "منشور")]
        Published = 5,
        [Display(Name = "غير منشور")]
        Unpublished = 6,
        [Display(Name = "مؤرشف")]
        Archived = 7,
    }
}
