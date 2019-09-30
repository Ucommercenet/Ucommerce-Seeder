using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceSystemVersion
    {
        public int SystemVersionId { get; set; }
        public int SchemaVersion { get; set; }
        public string AssemblyVersion { get; set; }
        public Guid Guid { get; set; }
    }
}
