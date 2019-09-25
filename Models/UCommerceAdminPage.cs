using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAdminPage
    {
        public UCommerceAdminPage()
        {
            UCommerceAdminTab = new HashSet<UCommerceAdminTab>();
        }

        public int AdminPageId { get; set; }
        public string FullName { get; set; }
        public string ActiveTab { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceAdminTab> UCommerceAdminTab { get; set; }
    }
}
