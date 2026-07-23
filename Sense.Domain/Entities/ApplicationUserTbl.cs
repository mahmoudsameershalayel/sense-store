using Sense.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ApplicationUserTbl : IdentityUser
    {
        public override string? Email { get; set; }
        public override string? UserName { get; set; }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? CompName { get; set; }
        public string? Phone1 { get; set; }                 
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ImageURL { get; set; }

        public bool? IsBlocked { get; set; }
        public string? FCMToken { get; set; }
        public string? ResetPasswordToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public int? HasNewNotifications { get; set; }
        public string? MyReferrerCode { get; set; }
        public string? ReferralCode { get; set; }
        public bool IsMyReferralCodeActive { get; set; } = false;
        public bool IsPhoneVerified { get; set; } = false;
        public int? MyPoints { get; set; }


    }
}
