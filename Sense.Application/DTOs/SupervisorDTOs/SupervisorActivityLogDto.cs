using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.SupervisorDTOs
{
    public class SupervisorActivityLogDto
    {
        public int Id { get; set; }
        public UserDto Supervisor { get; set; }

        public string? Description { get; set; }
        public string? ActivityType { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
