using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.BranchDTOs;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.ModelDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AppointmentDTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string? ModelYear { get; set; }
        public string? Details { get; set; }
        public string? ScheduledDate { get; set; }
        public string? ScheduledTime { get; set; }
        public string? CreatedAtDate { get; set; }
        public string Status { get; set; }
        public string? RejectReason { get; set; }
        public ServiceDto? Service { get; set; }
        public CustomerDto Customer { get; set; } = new CustomerDto();
        public SupervisorDto? Supervisor { get; set; }
        public BranchDto? Branch { get; set; }
        public BrandDto? Brand { get; set; }
        public ModelDto? Model { get; set; }
    }
}
