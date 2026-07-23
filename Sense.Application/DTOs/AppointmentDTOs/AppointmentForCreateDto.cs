using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AppointmentDTOs
{
    public class AppointmentForCreateDto
    {
        public string? ModelYear { get; set; }
        public string? Details { get; set; }
        public int? ServiceId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
    }
}
