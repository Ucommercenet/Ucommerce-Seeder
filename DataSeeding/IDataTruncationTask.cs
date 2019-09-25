using System.Threading.Tasks;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding
{
    public interface IDataTruncationTask
    {
        Task Truncate(UmbracoDbContext context);
    }
}