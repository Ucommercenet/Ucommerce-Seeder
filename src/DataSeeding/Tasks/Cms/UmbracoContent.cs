using System;
using System.Linq;
using Ucommerce.Seeder.DataAccess;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public class UmbracoContentProvider : ICmsContent
    {
        public readonly static Guid UmbracoMediaNodeType = new Guid("B796F64C-1F99-4FFB-B886-4BF4BC011A9C");
        public readonly static Guid UmbracoContentNodeType = new Guid("C66BA18E-EAF3-4CFF-8A22-41B16D66A972");

        public virtual string[] GetAllMediaIds(DataContext context)
        {
            return context.Cms.UmbracoNode
                .Where(x => x.NodeObjectType == UmbracoMediaNodeType)
                .Select(x => x.UniqueId.ToString()).ToArray();
        }

        public virtual string[] GetAllContentIds(DataContext context)
        {
            return context.Cms.UmbracoNode
                .Where(x => x.NodeObjectType == UmbracoContentNodeType)
                .Select(x => x.UniqueId.ToString()).ToArray();
        }

        public string[] GetLanguageIsoCodes(DataContext context)
        {
            return context.Cms.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
        }
    }
}