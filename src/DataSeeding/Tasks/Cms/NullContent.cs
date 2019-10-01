using System;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public class NullContent : ICmsContent
    {
        public Guid[] GetAllMediaIds(UmbracoDbContext context)
        {
            return new[] {Guid.Parse("749039d5-7137-48bd-a400-e11c4bbbaa57")};
        }

        public Guid[] GetAllContentIds(UmbracoDbContext context)
        {
            return new[] {Guid.Parse("21592d3b-1377-455e-9146-e97b51fb8778")};
        }

        public string[] GetLanguageIsoCodes(UmbracoDbContext context)
        {
            return new[] {"en-US"};
        }
    }
}