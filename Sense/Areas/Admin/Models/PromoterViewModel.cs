using System.ComponentModel.DataAnnotations;

namespace Sense.Areas.Admin.Models
{
    public class PromoterViewModel
    {
        [Required(ErrorMessage = "اسم المروج مطلوب")]
        [StringLength(100, ErrorMessage = "اسم المروج لا يمكن أن يتجاوز 100 حرفًا.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "رمز الدولة مطلوب")]
        public string CountryCode { get; set; } = "970";

        [Required(ErrorMessage = "رقم هاتف المروج مطلوب")]
        [RegularExpression(@"^0?5[0-9]{8}$", ErrorMessage = "رقم الهاتف غير صالح")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
