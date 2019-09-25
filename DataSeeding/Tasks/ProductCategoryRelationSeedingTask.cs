using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class ProductCategoryRelationSeedingTask : DataSeedingTaskBase
    {
        private readonly DatabaseSize _databaseSize;
        private readonly Faker<UCommerceCategoryProductRelation> _faker;

        public ProductCategoryRelationSeedingTask(DatabaseSize databaseSize) : base(
            databaseSize.AverageProductsPerCategory * databaseSize.CategoriesPerCatalog *
            databaseSize.CatalogsPerStore * databaseSize.Stores)
        {
            _databaseSize = databaseSize;

            _faker = new Faker<UCommerceCategoryProductRelation>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.SortOrder, f => f.Random.Int(0, (int) Count));
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            int[] productIds = context.UCommerceProduct
                .Where(product => product.UCommerceCategoryProductRelation.Count == 0)
                .Where(product => product.ParentProductId == null) // not variants
                .Select(x => x.ProductId).ToArray();

            int[] categoryIds = context.UCommerceCategory.Select(x => x.CategoryId).ToArray();

            uint batchSize = 100_000;
            uint batchCount = Count / batchSize;
            Console.Write(
                $"Generating {Count:N0} relations for {productIds.Length:N0} products and {categoryIds.Length:N0} categories in batches of {batchSize:N0}. ");
            using (var p = new ProgressBar())
            {
                var relationBatches = GeneratorHelper
                    .Generate(() => GenerateRelation(productIds, categoryIds), Count)
                    .DistinctBy(a => a.UniqueIndex())
                    .Batch(batchSize);

                await relationBatches.EachWithIndexAsync(async (relations, index) =>
                {
                    await context.BulkInsertAsync(relations, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / batchCount);
                });
            }
        }

        private UCommerceCategoryProductRelation GenerateRelation(int[] productIds, int[] categoryIds)
        {
            return _faker
                .RuleFor(x => x.ProductId, f => f.PickRandom(productIds))
                .RuleFor(x => x.CategoryId, f => f.PickRandom(categoryIds))
                .Generate();
        }

        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(
                new RawSqlString($"TRUNCATE TABLE [Ucommerce_CategoryProductRelation]"));
        }
    }
}