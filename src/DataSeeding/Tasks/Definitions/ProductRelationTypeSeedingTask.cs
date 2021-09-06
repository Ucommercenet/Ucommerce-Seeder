using System;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataAccess;
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

        public override void Seed(DataContext context)
        {
            Console.Write($"Generating {Count:N0} product relation types. ");
            using (var p = new ProgressBar())
            {
                var dataTypes = GeneratorHelper.Generate(Generate, Count);
                p.Report(0.5);
                context.Ucommerce.BulkInsert(dataTypes, options => options.SetOutputIdentity = false);
            }
        }

        private UCommerceProductRelationType Generate()
        {
            return _productRelationTypeFaker.Generate();
        }
    }
}