using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class OrderNumberSeriesSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceOrderNumberSerie> _faker;

        public OrderNumberSeriesSeedingTask(uint count) : base(count)
        {
            _faker = new Faker<UCommerceOrderNumberSerie>()
                    .RuleFor(x => x.Deleted, f => f.Random.Bool(0.1f))
                    .RuleFor(x => x.Guid, f => f.Random.Guid())
                    .RuleFor(x => x.Increment, f => 1)
                    .RuleFor(x => x.Postfix, f => f.Lorem.Word())
                    .RuleFor(x => x.Prefix, f => f.Lorem.Word())
                    .RuleFor(x => x.CurrentNumber, f => f.Random.Int(0,100_000))
                    .RuleFor(x => x.OrderNumberName, f => f.Company.CatchPhrase());
        }

        public override void Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count:N0} order number series. ");
            using (var p = new ProgressBar())
            {
                p.Report(0.1);
                var orderNumberSeries =
                    GeneratorHelper.Generate(() => _faker.Generate(), Count);
                p.Report(0.5);
                context.BulkInsert(orderNumberSeries);
            }
        }
    }
}