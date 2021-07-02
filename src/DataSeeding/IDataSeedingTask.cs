using System;
using System.Threading.Tasks;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding
{
    public interface IDataSeedingTask
    {
        void Seed(UmbracoDbContext context);
        uint Count { get; }
    }
}