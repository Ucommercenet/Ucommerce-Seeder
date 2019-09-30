using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsPropertyType
    {
        public CmsPropertyType()
        {
            CmsTagRelationship = new HashSet<CmsTagRelationship>();
            UmbracoPropertyData = new HashSet<UmbracoPropertyData>();
        }

        public int Id { get; set; }
        public int DataTypeId { get; set; }
        public int ContentTypeId { get; set; }
        public int? PropertyTypeGroupId { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool? Mandatory { get; set; }
        public string ValidationRegExp { get; set; }
        public string Description { get; set; }
        public int Variations { get; set; }
        public Guid UniqueId { get; set; }

        public virtual CmsContentType ContentType { get; set; }
        public virtual UmbracoDataType DataType { get; set; }
        public virtual CmsPropertyTypeGroup PropertyTypeGroup { get; set; }
        public virtual ICollection<CmsTagRelationship> CmsTagRelationship { get; set; }
        public virtual ICollection<UmbracoPropertyData> UmbracoPropertyData { get; set; }
    }
}
