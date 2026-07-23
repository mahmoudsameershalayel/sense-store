using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Sense.Models.ProviderRegistration
{
    public class ProviderRegistrationViewModel
    {
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

        [Required(ErrorMessage = "وصف النشاط التجاري مطلوب.")]
        [StringLength(3000, MinimumLength = 20, ErrorMessage = "يجب أن يتراوح الوصف بين 20 و3000 حرف.")]
        [Display(Name = "وصف النشاط التجاري")]
        public string BusinessDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "يرجى إرفاق الهوية أو السجل/الرخصة التجارية.")]
        [Display(Name = "وثيقة التحقق")]
        public IFormFile? Document { get; set; }

        [MustBeTrue(ErrorMessage = "يجب الموافقة على الشروط وصحة البيانات.")]
        [Display(Name = "الموافقة على الشروط")]
        public bool AcceptedTerms { get; set; }
    }

    public class ProviderRequestReviewViewModel
    {
        public int Id { get; set; }

        [StringLength(3000, ErrorMessage = "الملاحظة الداخلية لا يمكن أن تتجاوز 3000 حرف.")]
        public string? InternalNote { get; set; }

        [StringLength(2000, ErrorMessage = "سبب الرفض لا يمكن أن يتجاوز 2000 حرف.")]
        public string? RejectionReason { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public sealed class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value) => value is true;
    }
}
