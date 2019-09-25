using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoServer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ComputerName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime LastNotifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsMaster { get; set; }
    }
}
