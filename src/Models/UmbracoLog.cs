using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int NodeId { get; set; }
        public string EntityType { get; set; }
        public DateTime Datestamp { get; set; }
        public string LogHeader { get; set; }
        public string LogComment { get; set; }
        public string Parameters { get; set; }

        public virtual UmbracoUser User { get; set; }
    }
}
