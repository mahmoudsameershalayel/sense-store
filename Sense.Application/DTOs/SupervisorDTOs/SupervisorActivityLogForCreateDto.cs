using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.SupervisorDTOs
{
    public class SupervisorActivityLogForCreateDto
    {
        public int SupervisorId { get; set; }

        public string? Description { get; set; }
        public ActivityType? ActivityType { get; set; }
    }
}
