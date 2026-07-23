using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.SupervisorDTOs
{
    public class SupervisorReportDto
    {
        public string SupervisorName { get; set; }
        public string BranchName { get; set; }

        public int TotalMaintenanceRecords { get; set; }
        public int TotalAppointments { get; set; }

        // Optional: Add more stats
        public List<string> RecentAppointments { get; set; } = new();
        public List<string> RecentMaintenance { get; set; } = new();
        public List<SupervisorRecentLogDto> RecentLogs { get; set; } = new();
        public Dictionary<string, int>? ActivityLogStats { get; set; } = new();
    }
}
