using System;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class CurrencySeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceCurrency> _currencyFaker;

        public CurrencySeedingTask(uint count) : base(count)
        {
            _currencyFaker = new Faker<UCommerceCurrency>()
                .RuleFor(x => x.Isocode, f => f.Finance.Currency().Code)
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f));
        }

        public string TaskName => GetType().Name;

        public override async Task Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count} currencies. ");
            using (var p = new ProgressBar())
            {
                var currencies = GeneratorHelper.Generate(GenerateCurrency, Count);
                p.Report(0.5);
                await context.BulkInsertAsync(currencies, options => options.AutoMapOutputDirection = false);
            }
        }

        private UCommerceCurrency GenerateCurrency()
        {
            return _currencyFaker.Generate();
        }
        
    }
}