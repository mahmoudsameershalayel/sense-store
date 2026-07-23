using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OfferCashbackDTOs
{
    public class CashbackOfferDto
    {
        public int Id { get; set; }
        public string CashbackType { get; set; }
        public decimal CashbackVal { get; set; }
        public string ReturnType { get; set; }
        public bool IsApplyOnSparePart { get; set; }
        public bool IsApplyOnLaborCost { get; set; }
        public bool IsApplyOnStore { get; set; }
        public string? ImageURL { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
