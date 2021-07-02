using System;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public class NullContent : ICmsContent
    {
        public string[] GetAllMediaIds(UmbracoDbContext context)
        {
            return new string[0];
        }

        public string[] GetAllContentIds(UmbracoDbContext context)
        {
            return new string[0];
        }

        public string[] GetLanguageIsoCodes(UmbracoDbContext context)
        {
            return new[] {"en-US"};
        }
    }
}