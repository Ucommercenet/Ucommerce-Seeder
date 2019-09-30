using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoNode
    {
        public UmbracoNode()
        {
            CmsContentType2ContentTypeChildContentType = new HashSet<CmsContentType2ContentType>();
            CmsContentType2ContentTypeParentContentType = new HashSet<CmsContentType2ContentType>();
            CmsDocumentType = new HashSet<CmsDocumentType>();
            CmsMember2MemberGroup = new HashSet<CmsMember2MemberGroup>();
            CmsMemberType = new HashSet<CmsMemberType>();
            InverseParent = new HashSet<UmbracoNode>();
            UmbracoAccessLoginNode = new HashSet<UmbracoAccess>();
            UmbracoAccessNoAccessNode = new HashSet<UmbracoAccess>();
            UmbracoDocumentCultureVariation = new HashSet<UmbracoDocumentCultureVariation>();
            UmbracoDomain = new HashSet<UmbracoDomain>();
            UmbracoRedirectUrl = new HashSet<UmbracoRedirectUrl>();
            UmbracoRelationChild = new HashSet<UmbracoRelation>();
            UmbracoRelationParent = new HashSet<UmbracoRelation>();
            UmbracoUser2NodeNotify = new HashSet<UmbracoUser2NodeNotify>();
            UmbracoUserGroup2NodePermission = new HashSet<UmbracoUserGroup2NodePermission>();
            UmbracoUserGroupStartContent = new HashSet<UmbracoUserGroup>();
            UmbracoUserGroupStartMedia = new HashSet<UmbracoUserGroup>();
            UmbracoUserStartNode = new HashSet<UmbracoUserStartNode>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
        public string Path { get; set; }
        public int SortOrder { get; set; }
        public bool? Trashed { get; set; }
        public int? NodeUser { get; set; }
        public string Text { get; set; }
        public Guid? NodeObjectType { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual UmbracoUser NodeUserNavigation { get; set; }
        public virtual UmbracoNode Parent { get; set; }
        public virtual CmsContentType CmsContentType { get; set; }
        public virtual CmsTemplate CmsTemplate { get; set; }
        public virtual UmbracoAccess UmbracoAccessNode { get; set; }
        public virtual UmbracoContent UmbracoContent { get; set; }
        public virtual UmbracoDataType UmbracoDataType { get; set; }
        public virtual ICollection<CmsContentType2ContentType> CmsContentType2ContentTypeChildContentType { get; set; }
        public virtual ICollection<CmsContentType2ContentType> CmsContentType2ContentTypeParentContentType { get; set; }
        public virtual ICollection<CmsDocumentType> CmsDocumentType { get; set; }
        public virtual ICollection<CmsMember2MemberGroup> CmsMember2MemberGroup { get; set; }
        public virtual ICollection<CmsMemberType> CmsMemberType { get; set; }
        public virtual ICollection<UmbracoNode> InverseParent { get; set; }
        public virtual ICollection<UmbracoAccess> UmbracoAccessLoginNode { get; set; }
        public virtual ICollection<UmbracoAccess> UmbracoAccessNoAccessNode { get; set; }
        public virtual ICollection<UmbracoDocumentCultureVariation> UmbracoDocumentCultureVariation { get; set; }
        public virtual ICollection<UmbracoDomain> UmbracoDomain { get; set; }
        public virtual ICollection<UmbracoRedirectUrl> UmbracoRedirectUrl { get; set; }
        public virtual ICollection<UmbracoRelation> UmbracoRelationChild { get; set; }
        public virtual ICollection<UmbracoRelation> UmbracoRelationParent { get; set; }
        public virtual ICollection<UmbracoUser2NodeNotify> UmbracoUser2NodeNotify { get; set; }
        public virtual ICollection<UmbracoUserGroup2NodePermission> UmbracoUserGroup2NodePermission { get; set; }
        public virtual ICollection<UmbracoUserGroup> UmbracoUserGroupStartContent { get; set; }
        public virtual ICollection<UmbracoUserGroup> UmbracoUserGroupStartMedia { get; set; }
        public virtual ICollection<UmbracoUserStartNode> UmbracoUserStartNode { get; set; }
    }
}
