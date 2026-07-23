using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OfferCashbackDTOs
{
    public class CashbackOfferForUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "نوع الكاشباك مطلوب")]
        public CashbackType CashbackType { get; set; }

        [Required(ErrorMessage = "قيمة الكاشباك مطلوبة")]
        [Range(0.01, double.MaxValue, ErrorMessage = "قيمة الكاشباك يجب أن تكون أكبر من صفر")]
        public decimal CashbackVal { get; set; }

        [Required(ErrorMessage = "نوع الإرجاع مطلوب")]
        public ReturnType ReturnType { get; set; }

        public bool IsApplyOnSparePart { get; set; }
        public bool IsApplyOnLaborCost { get; set; }
        public bool IsApplyOnStore { get; set; }

        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "تاريخ البداية مطلوب")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "تاريخ النهاية مطلوب")]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
