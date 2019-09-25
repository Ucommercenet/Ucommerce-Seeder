using System;
using System.Threading.Tasks;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding
{
    public interface IDataSeedingTask
    {
        Task Seed(UmbracoDbContext context);
        uint Count { get; }
    }
}