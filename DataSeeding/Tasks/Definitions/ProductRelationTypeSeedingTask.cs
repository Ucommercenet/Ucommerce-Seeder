using System;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class ProductRelationTypeSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceProductRelationType> _productRelationTypeFaker;

        public ProductRelationTypeSeedingTask(uint count) : base(count)
        {
            _productRelationTypeFaker = new Faker<UCommerceProductRelationType>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent())
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.Name, f => f.Commerce.ProductAdjective());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count:N0} product relation types. ");
            using (var p = new ProgressBar())
            {
                var dataTypes = GeneratorHelper.Generate(Generate, Count);
                p.Report(0.5);
                await context.BulkInsertAsync(dataTypes, options => options.AutoMapOutputDirection = false);
            }
        }

        private UCommerceProductRelationType Generate()
        {
            return _productRelationTypeFaker.Generate();
        }
        
        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(new RawSqlString($"TRUNCATE TABLE [Ucommerce_ProductRelationType]"));
        }

    }
}