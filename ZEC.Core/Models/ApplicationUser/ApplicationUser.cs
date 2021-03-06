using Microsoft.AspNetCore.Identity;
using System;
using ZEC.Core.Models.ApplicationUser.UserInfo;
using ZEC.Core.Models.UserInfo;

namespace ZEC.Core.Models.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            DateUpdatedUtc = DateTime.UtcNow;
            CreatedOnUtc = DateTime.UtcNow;
        }

        //User Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Gender Gender { get; set; }
        public bool Active { get; set; }

        //Administration Info
        public string AdminComment { get; set; }
        public bool RequireReLogin { get; set; }
        public string EmailToRevalidate { get; set; }
        public int FailedLoginAttempts { get; set; }
        public int ActivationTokensRequested { get; set; }
        public int PasswordResetTokensRequested { get; set; }
        public int EmailChangeTokensRequested { get; set; }
        public DateTime? LastActivationTokenTimeStampUtc { get; set; }
        public DateTime? LastPasswordResetTokenTimeStampUtc { get; set; }
        public DateTime? LastEmailChangeTokenTimeStampUtc { get; set; }
        public DateTime DateUpdatedUtc { get; set; }
        public DateTime RegistrationDateUtc { get; set; }
        public DateTime? NotificationReadDate { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public DateTime? LastActivityDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string LastIpAddress { get; set; }
    }
}
