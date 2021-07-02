using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Ucommerce.Seeder.DataAccess;
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
        
        public override void Seed(DataContext context)
        {
            Console.Write($"Generating {Count} currencies. ");
            using (var p = new ProgressBar())
            {
                var defaultCurrenciesNotInDb = GetDefaultCurrenciesNotInDb(context);
                var currenciesLeft = Math.Max(0, Count - defaultCurrenciesNotInDb.Count);

                var currencies = currenciesLeft == 0
                    ? defaultCurrenciesNotInDb.Take((int) Count)
                    : defaultCurrenciesNotInDb.Concat(GeneratorHelper.Generate(GenerateCurrency, (uint)currenciesLeft))
                        .DistinctBy(x => x.Isocode);

                p.Report(0.5);
                context.BulkInsert(currencies.ToList(), options => options.SetOutputIdentity = false);
            }
        }

        private List<UCommerceCurrency> GetDefaultCurrenciesNotInDb(DataContext context)
        {
            var preSeededCurrencies = context.Ucommerce.UCommerceCurrency.ToList();

            return DefaultCurrencies.Where(x => !preSeededCurrencies
                    .Select(y => y.Isocode)
                    .Contains(x.Isocode))
                .ToList();
        }

        private UCommerceCurrency GenerateCurrency()
        {
            return _currencyFaker.Generate();
        }

        private static UCommerceCurrency[] DefaultCurrencies => new []
        {
            new UCommerceCurrency { Isocode  = "EUR", ExchangeRate = 100, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "DKK", ExchangeRate = 744, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "GBP", ExchangeRate = 88, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "USD", ExchangeRate = 143, Deleted = false, Guid = Guid.NewGuid() },
            new UCommerceCurrency { Isocode  = "AUD", ExchangeRate = 163, Deleted = false, Guid = Guid.NewGuid() },
        };
    }
}