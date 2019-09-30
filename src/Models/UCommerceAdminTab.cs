using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAdminTab
    {
        public int AdminTabId { get; set; }
        public string VirtualPath { get; set; }
        public int AdminPageId { get; set; }
        public int SortOrder { get; set; }
        public bool MultiLingual { get; set; }
        public string ResouceKey { get; set; }
        public bool? HasSaveButton { get; set; }
        public bool HasDeleteButton { get; set; }
        public bool Enabled { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceAdminPage AdminPage { get; set; }
    }
}
