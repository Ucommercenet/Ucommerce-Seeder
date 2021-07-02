using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.DataSeeding.Tasks;
using Ucommerce.Seeder.DataSeeding.Tasks.Cms;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding
{
    public class DataSeeder
    {
        private readonly DatabaseSize _sizeOptions;
        private readonly bool _excludeCmsTables;

        public DataSeeder(DatabaseSize sizeOptions, bool excludeCmsTables)
        {
            _sizeOptions = sizeOptions;
            _excludeCmsTables = excludeCmsTables;
        }

        //
        // Sets up a list of task, in the correct order, and executes each sequentially.
        // Each task represents one step in seeding the database. By splitting into discrete
        // tasks, we get the benefit of not depleting system ram.
        //
        // If the truncate option has been specified, the tasks will truncate each their tables
        // in reverse seeding order.
        //
        public void Seed(Func<UmbracoDbContext> dbContextFactory)
        {
            var masterStopwatch = new Stopwatch();
            masterStopwatch.Start();

            using (var context = dbContextFactory())
            {
                // For now, only Umbraco is supported.
                // You can disable Umbraco media seeding
                ICmsContent cmsContent = _excludeCmsTables ? new NullContent() as ICmsContent : new UmbracoContentProvider();

                var seedingTasks = new List<IDataSeedingTask>
                {
                    new DefinitionSeedingTask(_sizeOptions.Definitions),
                    new DefinitionFieldSeedingTask(_sizeOptions.Definitions *
                                                   _sizeOptions.AverageUserDefinedFieldsPerDefinition, cmsContent),

                    new DataTypeSeedingTask(_sizeOptions.DataTypes, cmsContent),
                    new CurrencySeedingTask(_sizeOptions.Currencies),
                    new PriceGroupSeedingTask(_sizeOptions.PriceGroups),
                    new ProductRelationTypeSeedingTask(_sizeOptions.ProductRelationTypes),
                    new OrderNumberSeriesSeedingTask(_sizeOptions.OrderNumberSeries),

                    new ProductDefinitionSeedingTask(_sizeOptions.ProductDefinitions),
                    new ProductDefinitionFieldsSeedingTask(_sizeOptions.AverageUserDefinedFieldsPerDefinition *
                                                           _sizeOptions.ProductDefinitions, cmsContent),

                    new StoreSeedingTask(_sizeOptions.Stores, cmsContent),
                    new CatalogSeedingTask(_sizeOptions.CatalogsPerStore * _sizeOptions.Stores, cmsContent),
                    new CategorySeedingTask(_sizeOptions.Stores * _sizeOptions.CatalogsPerStore *
                                            _sizeOptions.CategoriesPerCatalog, cmsContent),

                    new ProductSeedingTask(_sizeOptions, cmsContent),
                    new VariantSeedingTask(_sizeOptions, cmsContent),

                    new ProductCategoryRelationSeedingTask(_sizeOptions),
                };

                if (!_excludeCmsTables)
                {
                    seedingTasks.Insert(0, new UmbracoMediaSeedingTask(_sizeOptions));
                    seedingTasks.Insert(1, new LanguageSeedingTask(_sizeOptions.Languages));
                }

                foreach (var task in seedingTasks)
                {
                    task.Seed(context);
                }
            }

            masterStopwatch.Stop();
            TimeSpan ts = masterStopwatch.Elapsed;
            string formattedSpan = $"{ts.Days:D2}:{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";
            Console.WriteLine($"All tasks completed in {formattedSpan}");
        }
    }
}