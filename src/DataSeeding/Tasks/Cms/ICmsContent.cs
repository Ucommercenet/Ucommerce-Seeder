using System;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Cms
{
    public interface ICmsContent
    {
        string[] GetAllMediaIds(DataContext context);
        string[] GetAllContentIds(DataContext context);
        string[] GetLanguageIsoCodes(DataContext context);
    }
}