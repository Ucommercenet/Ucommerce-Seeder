using System;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public interface ICmsContent
    {
        Guid[] GetAllMediaIds(UmbracoDbContext context);
        Guid[] GetAllContentIds(UmbracoDbContext context);
        string[] GetLanguageIsoCodes(UmbracoDbContext context);
    }
}