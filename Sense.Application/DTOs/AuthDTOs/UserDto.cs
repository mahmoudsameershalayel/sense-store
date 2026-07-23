using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AuthDTOs
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string? CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? FCMToken { get; set; }
        public string? UserType { get; set; }
        public bool IsActive { get; set; }
        public int HasNewNotifications { get; set; }
        public int? MyPoints { get; set; }
        public string? ImageURL { get; set; }
    }
}
