using Ucommerce.Seeder.DataAccess;

namespace Ucommerce.Seeder.DataSeeding
{
    public interface IDataSeedingTask
    {
        void Seed(DataContext context);
        uint Count { get; }
    }
}