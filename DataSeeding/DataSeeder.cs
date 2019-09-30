using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ucommerce.Seeder.DataSeeding.Tasks;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding
{
    public class DataSeeder
    {
        private readonly DatabaseSize _sizeOptions;

        public DataSeeder(DatabaseSize sizeOptions)
        {
            _sizeOptions = sizeOptions;
        }

        //
        // Sets up a list of task, in the correct order, and executes each sequentially.
        // Each task represents one step in seeding the database. By splitting into discrete
        // tasks, we get the benefit of not depleting system ram.
        //
        // If the truncate option has been specified, the tasks will truncate each their tables
        // in reverse seeding order.
        //
        public async Task Seed(Func<UmbracoDbContext> dbContextFactory)
        {
            var masterStopwatch = new Stopwatch();
            masterStopwatch.Start();

            var seedingTasks = new List<IDataSeedingTask>
            {
                new MediaSeedingTask(_sizeOptions),

                new DefinitionSeedingTask(_sizeOptions.Definitions),
                new DefinitionFieldSeedingTask(_sizeOptions.Definitions *
                                               _sizeOptions.AverageUserDefinedFieldsPerDefinition),

                new DataTypeSeedingTask(_sizeOptions.DataTypes),
                new LanguageSeedingTask(_sizeOptions.Languages),
                new CurrencySeedingTask(_sizeOptions.Currencies),
                new PriceGroupSeedingTask(_sizeOptions.PriceGroups),
                new ProductRelationTypeSeedingTask(_sizeOptions.ProductRelationTypes),

                new ProductDefinitionSeedingTask(_sizeOptions.ProductDefinitions),
                new ProductDefinitionFieldsSeedingTask(_sizeOptions.AverageUserDefinedFieldsPerDefinition *
                                                       _sizeOptions.ProductDefinitions),

                new StoreSeedingTask(_sizeOptions.Stores),
                new CatalogSeedingTask(_sizeOptions.CatalogsPerStore * _sizeOptions.Stores),
                new CategorySeedingTask(_sizeOptions.Stores * _sizeOptions.CatalogsPerStore *
                                        _sizeOptions.CategoriesPerCatalog),

                new ProductSeedingTask(_sizeOptions),
                new VariantSeedingTask(_sizeOptions),

                new ProductCategoryRelationSeedingTask(_sizeOptions),
            };

            using (var context = dbContextFactory())
            {
                foreach (var task in seedingTasks)
                {
                    await task.Seed(context);
                }
            }

            masterStopwatch.Stop();
            TimeSpan ts = masterStopwatch.Elapsed;
            string formattedSpan = $"{ts.Days:D2}:{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";
            Console.WriteLine($"All tasks completed in {formattedSpan}");
        }
    }
}