using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
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
        
        public override async Task Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count} currencies. ");
            using (var p = new ProgressBar())
            {
                var currenciesLeft = Count - DefaultCurrencies.Length;

                var currencies = currenciesLeft <= 0
                    ? DefaultCurrencies.Take((int) Count)
                    : DefaultCurrencies.Concat(GeneratorHelper.Generate(GenerateCurrency, (uint)currenciesLeft));

                p.Report(0.5);
                await context.BulkInsertAsync(currencies, options => options.AutoMapOutputDirection = false);
            }
        }

        private UCommerceCurrency GenerateCurrency()
        {
            return _currencyFaker.Generate();
        }

        private static UCommerceCurrency[] DefaultCurrencies => new []
        {
            new UCommerceCurrency { Isocode  = "EUR", ExchangeRate = 100, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "DKK", ExchangeRate = 744, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "GPP", ExchangeRate = 88, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "USD", ExchangeRate = 143, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "AUD", ExchangeRate = 163, Deleted = false, Guid = Guid.NewGuid() },
        };
    }
}