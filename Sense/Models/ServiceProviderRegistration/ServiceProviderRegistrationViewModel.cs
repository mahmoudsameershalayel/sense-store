using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Sense.Models.ProviderRegistration;

namespace Sense.Models.ServiceProviderRegistration
{
    public class ServiceProviderRegistrationViewModel
    {
        [Required(ErrorMessage = "اسم مقدم الطلب مطلوب.")]
        [StringLength(150, ErrorMessage = "اسم مقدم الطلب لا يمكن أن يتجاوز 150 حرفاً.")]
        [Display(Name = "اسم مقدم الطلب")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "اسم النشاط مطلوب.")]
        [StringLength(180, ErrorMessage = "اسم النشاط لا يمكن أن يتجاوز 180 حرفاً.")]
        [Display(Name = "اسم النشاط")]
        public string BusinessName { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب.")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح.")]
        [StringLength(256)]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم الهاتف مطلوب.")]
        [Phone(ErrorMessage = "رقم الهاتف غير صالح.")]
        [StringLength(25, ErrorMessage = "رقم الهاتف لا يمكن أن يتجاوز 25 حرفاً.")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "كلمتا المرور غير متطابقتين.")]
        [Display(Name = "تأكيد كلمة المرور")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "وصف الخدمات مطلوب.")]
        [StringLength(3000, MinimumLength = 20, ErrorMessage = "يجب أن يتراوح الوصف بين 20 و3000 حرف.")]
        [Display(Name = "وصف الخدمات")]
        public string BusinessDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "صورة الملف الشخصي مطلوبة.")]
        [Display(Name = "صورة الملف الشخصي")]
        public IFormFile? ProfileImage { get; set; }

        [MustBeTrue(ErrorMessage = "يجب الموافقة على الشروط وصحة البيانات.")]
        [Display(Name = "الموافقة على الشروط")]
        public bool AcceptedTerms { get; set; }
    }
}
