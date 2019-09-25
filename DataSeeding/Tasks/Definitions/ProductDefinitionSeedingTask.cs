﻿using System;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    internal class ProductDefinitionSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceProductDefinition> _productDefinitionFaker;

        public ProductDefinitionSeedingTask(uint amount) : base(amount)
        {
            _productDefinitionFaker = new Faker<UCommerceProductDefinition>()
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Description, f => f.Lorem.Sentence())
                .RuleFor(x => x.Guid, f => f.Random.Guid());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count:N0} product definitions. ");
            using (var p = new ProgressBar())
            {
                var productDefinitions = GeneratorHelper.Generate(Generate, Count);
                p.Report(0.33);
                productDefinitions.ConsecutiveSortOrder((def, val) => { def.SortOrder = (int) val; });
                p.Report(0.66);
                await context.BulkInsertAsync(productDefinitions, options => options.AutoMapOutputDirection = false);
            }

        }

        private UCommerceProductDefinition Generate()
        {
            return _productDefinitionFaker.Generate();
        }
        
        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(new RawSqlString($"TRUNCATE TABLE [Ucommerce_ProductDefinition]"));
        }

    }
}