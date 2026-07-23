using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.TechSupportDTOs
{
    public class TechSupportDto
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? FCMToken { get; set; }
        public bool IsActive { get; set; }
        public int HasNewNotifications { get; set; }
        public UserType UserType { get; set; }
        public string ImageURL { get; set; }
    }
}
