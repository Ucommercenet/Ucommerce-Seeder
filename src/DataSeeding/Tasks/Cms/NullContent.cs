using System;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public class NullContent : ICmsContent
    {
        public string[] GetAllMediaIds(DataContext context)
        {
            return new string[0];
        }

        public string[] GetAllContentIds(DataContext context)
        {
            return new string[0];
        }

        public string[] GetLanguageIsoCodes(DataContext context)
        {
            return new[] {"en-US"};
        }
    }
}