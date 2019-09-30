using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsContentTypeAllowedContentType
    {
        public int Id { get; set; }
        public int AllowedId { get; set; }
        public int SortOrder { get; set; }

        public virtual CmsContentType Allowed { get; set; }
        public virtual CmsContentType IdNavigation { get; set; }
    }
}
