using System;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public interface ICmsContent
    {
        string[] GetAllMediaIds(UmbracoDbContext context);
        string[] GetAllContentIds(UmbracoDbContext context);
        string[] GetLanguageIsoCodes(UmbracoDbContext context);
    }
}