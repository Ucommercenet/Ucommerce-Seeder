using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class StoreSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceProductCatalogGroup> _storeFaker;

        public StoreSeedingTask(uint count) : base(count)
        {
            _storeFaker = new Faker<UCommerceProductCatalogGroup>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Commerce.Department())
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.DomainId, f => f.Internet.Url())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.CatalogGroup).Select(c => c.DefinitionId)
                .ToArray();

            var stores = await GenerateStores(context, definitionIds);

            await GenerateProperties(context, definitionIds, stores);
        }

        private async Task GenerateProperties(UmbracoDbContext context, int[] definitionIds,
            UCommerceProductCatalogGroup[] stores)
        {
            Console.Write($"Generating properties for {Count:N0} stores. ");
            using (var p = new ProgressBar())
            {
                var mediaIds = GetAllMediaIds(context);
                var contentIds = GetAllContentIds(context);
                var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
                var definitionFields = LookupDefinitionFields(context, definitionIds);
                p.Report(0.1);

                UCommerceEntityProperty[] properties = stores
                    .Where(store => store.DefinitionId.HasValue)
                    .SelectMany(store => definitionFields[store.DefinitionId.Value].SelectMany(field =>
                        AddEntityProperty(store.Guid, field.Field, languageCodes, mediaIds,
                            contentIds, field.Editor, field.Enums)))
                    .ToArray();

                p.Report(0.5);
                await context.BulkInsertAsync(properties, options => options.AutoMapOutputDirection = false);
            }
        }

        private async Task<UCommerceProductCatalogGroup[]> GenerateStores(UmbracoDbContext context, int[] definitionIds)
        {
            Console.Write($"Generating {Count:N0} stores. ");
            using (var p = new ProgressBar())
            {
                var emailProfileIds = context.UCommerceEmailProfile.Select(x => x.EmailProfileId).ToArray();
                var currencyIds = context.UCommerceCurrency.Select(c => c.CurrencyId).ToArray();
                p.Report(0.1);
                var stores =
                    GeneratorHelper.Generate(() => GenerateStore(currencyIds, definitionIds, emailProfileIds), Count);
                p.Report(0.5);
                await context.BulkInsertAsync(stores);
                return stores;
            }
        }

        private UCommerceProductCatalogGroup GenerateStore(int[] currencyIds, int[] definitionIds,
            int[] emailProfileIds)
        {
            return _storeFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.CurrencyId, f => f.PickRandom(currencyIds))
                .RuleFor(x => x.EmailProfileId, f => f.PickRandom(emailProfileIds))
                .Generate();
        }

        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(
                new RawSqlString($"TRUNCATE TABLE [Ucommerce_ProductCatalogGroup]"));
        }
    }
}