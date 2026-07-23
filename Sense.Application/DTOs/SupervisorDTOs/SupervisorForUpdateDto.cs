using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.SupervisorDTOs
{
    public class SupervisorForUpdateDto
    {
        public string Id { get; set; }
        public int BranchId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
    }
}
