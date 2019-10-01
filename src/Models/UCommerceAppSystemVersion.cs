using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAppSystemVersion
    {
        public int AppSystemVersionId { get; set; }
        public int SchemaVersion { get; set; }
        public string MigrationName { get; set; }
        public Guid Guid { get; set; }
    }
}
