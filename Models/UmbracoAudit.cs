﻿using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoAudit
    {
        public int Id { get; set; }
        public int PerformingUserId { get; set; }
        public string PerformingDetails { get; set; }
        public string PerformingIp { get; set; }
        public DateTime EventDateUtc { get; set; }
        public int AffectedUserId { get; set; }
        public string AffectedDetails { get; set; }
        public string EventType { get; set; }
        public string EventDetails { get; set; }
    }
}
