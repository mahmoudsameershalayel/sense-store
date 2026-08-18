using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Sense.Models.ProviderRegistration
{
    public class ProviderRegistrationViewModel
    {
        [StringLength(100)]
        public string? BusinessCategoryKey { get; set; }

        public string? BusinessCategoryName { get; set; }

        [StringLength(100)]
        public string? StorefrontTemplateKey { get; set; }

        [Required(ErrorMessage = "اسم مقدم الطلب مطلوب.")]
        [StringLength(150, ErrorMessage = "اسم مقدم الطلب لا يمكن أن يتجاوز 150 حرفاً.")]
        [Display(Name = "اسم مقدم الطلب")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "اسم النشاط التجاري مطلوب.")]
        [StringLength(180, ErrorMessage = "اسم النشاط التجاري لا يمكن أن يتجاوز 180 حرفاً.")]
        [Display(Name = "اسم النشاط التجاري")]
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

        [Required(ErrorMessage = "وصف النشاط التجاري مطلوب.")]
        [StringLength(3000, MinimumLength = 20, ErrorMessage = "يجب أن يتراوح الوصف بين 20 و3000 حرف.")]
        [Display(Name = "وصف النشاط التجاري")]
        public string BusinessDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "صورة الملف الشخصي مطلوبة.")]
        [Display(Name = "صورة الملف الشخصي")]
        public IFormFile? ProfileImage { get; set; }

        [MustBeTrue(ErrorMessage = "يجب الموافقة على الشروط وصحة البيانات.")]
        [Display(Name = "الموافقة على الشروط")]
        public bool AcceptedTerms { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value) => value is true;
    }
}
