using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoUser
    {
        public UmbracoUser()
        {
            UmbracoContentVersion = new HashSet<UmbracoContentVersion>();
            UmbracoContentVersionCultureVariation = new HashSet<UmbracoContentVersionCultureVariation>();
            UmbracoLog = new HashSet<UmbracoLog>();
            UmbracoNode = new HashSet<UmbracoNode>();
            UmbracoUser2NodeNotify = new HashSet<UmbracoUser2NodeNotify>();
            UmbracoUser2UserGroup = new HashSet<UmbracoUser2UserGroup>();
            UmbracoUserLogin = new HashSet<UmbracoUserLogin>();
            UmbracoUserStartNode = new HashSet<UmbracoUserStartNode>();
        }

        public int Id { get; set; }
        public bool? UserDisabled { get; set; }
        public bool? UserNoConsole { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string PasswordConfig { get; set; }
        public string UserEmail { get; set; }
        public string UserLanguage { get; set; }
        public string SecurityStampToken { get; set; }
        public int? FailedLoginAttempts { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
        public DateTime? InvitedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Avatar { get; set; }
        public string TourData { get; set; }

        public virtual ICollection<UmbracoContentVersion> UmbracoContentVersion { get; set; }
        public virtual ICollection<UmbracoContentVersionCultureVariation> UmbracoContentVersionCultureVariation { get; set; }
        public virtual ICollection<UmbracoLog> UmbracoLog { get; set; }
        public virtual ICollection<UmbracoNode> UmbracoNode { get; set; }
        public virtual ICollection<UmbracoUser2NodeNotify> UmbracoUser2NodeNotify { get; set; }
        public virtual ICollection<UmbracoUser2UserGroup> UmbracoUser2UserGroup { get; set; }
        public virtual ICollection<UmbracoUserLogin> UmbracoUserLogin { get; set; }
        public virtual ICollection<UmbracoUserStartNode> UmbracoUserStartNode { get; set; }
    }
}
