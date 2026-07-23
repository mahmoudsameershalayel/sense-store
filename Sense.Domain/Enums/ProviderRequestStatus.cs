using System.ComponentModel.DataAnnotations;

namespace Sense.Domain.Enums
{
    public enum ProviderRequestStatus
    {
        [Display(Name = "قيد المراجعة")]
        Pending = 1,

        [Display(Name = "مقبول")]
        Approved = 2,

        [Display(Name = "مرفوض")]
        Rejected = 3
    }
}
