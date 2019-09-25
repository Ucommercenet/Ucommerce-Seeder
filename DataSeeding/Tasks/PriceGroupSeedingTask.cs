using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class PriceGroupSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker _faker;
        private readonly Faker<UCommercePriceGroup> _priceGroupFaker;

        public PriceGroupSeedingTask(uint count) : base(count)
        {
            _faker = new Faker();
            _priceGroupFaker = new Faker<UCommercePriceGroup>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent())
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count:N0} price groups. ");
            using (var p = new ProgressBar())
            {
                var currencyIds = context.UCommerceCurrency.Select(x => new Tuple<int, string>(x.CurrencyId, x.Isocode))
                    .ToArray();
                p.Report(0.1);

                var priceGroups = GeneratorHelper.Generate(() => Generate(currencyIds), Count)
                    .DistinctBy(x => x.UniqueIndex())
                    .ToArray();
                
                p.Report(0.5);

                await context.BulkInsertAsync(priceGroups, options => options.AutoMapOutputDirection = false);
            }
        }

        private UCommercePriceGroup Generate(IEnumerable<Tuple<int, string>> currencyIds)
        {
            var (currencyId, currencyName) = _faker.PickRandom(currencyIds);
            var vatRate = Math.Round(_faker.Random.Decimal(0.0M, 0.25M), 2);
            var name = _faker.Random.Bool() ? _faker.Commerce.Department() : $"{currencyName} {vatRate * 100} % VAT";
            return _priceGroupFaker
                .RuleFor(x => x.CurrencyId, f => currencyId)
                .RuleFor(x => x.Name, f => name)
                .RuleFor(x => x.Vatrate, f => vatRate)
                .Generate();
        }
        
        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(new RawSqlString($"TRUNCATE TABLE [Ucommerce_PriceGroup]"));
        }

    }
}