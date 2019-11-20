using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Tasks.Cms;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class StoreSeedingTask : DataSeedingTaskBase
    {
        private readonly ICmsContent _cmsContent;
        private readonly Faker<UCommerceProductCatalogGroup> _storeFaker;

        public StoreSeedingTask(uint count, ICmsContent cmsContent) : base(count)
        {
            _cmsContent = cmsContent;
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

        public override void Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.CatalogGroup).Select(c => c.DefinitionId)
                .ToArray();

            var stores = GenerateStores(context, definitionIds);

            GenerateProperties(context, definitionIds, stores);
        }

        private void GenerateProperties(UmbracoDbContext context, int[] definitionIds,
            IEnumerable<UCommerceProductCatalogGroup> stores)
        {
            Console.Write($"Generating properties for {Count:N0} stores. ");
            using (var p = new ProgressBar())
            {
                var mediaIds = _cmsContent.GetAllMediaIds(context);
                var contentIds = _cmsContent.GetAllContentIds(context);
                var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
                var definitionFields = LookupDefinitionFields(context, definitionIds);

                uint batchSize = 100_000;
                uint numberOfBatches = definitionFields.Any() ? 1 + (uint) stores.Count() * (uint) definitionFields.Average(x => x.Count()) / batchSize : 1;

                var propertyBatches = stores
                    .Where(store => store.DefinitionId.HasValue)
                    .SelectMany(store => definitionFields[store.DefinitionId.Value].SelectMany(field =>
                        AddEntityProperty(store.Guid, field.Field, languageCodes, mediaIds,
                            contentIds, field.Editor, field.Enums)))
                    .Batch(batchSize);

                propertyBatches.EachWithIndex((properties, index) =>
                {
                    context.BulkInsert(properties.ToList(), options => options.SetOutputIdentity = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private List<UCommerceProductCatalogGroup> GenerateStores(UmbracoDbContext context, int[] definitionIds)
        {
            Console.Write($"Generating {Count:N0} stores. ");
            using (var p = new ProgressBar())
            {
                var emailProfileIds = context.UCommerceEmailProfile.Select(x => x.EmailProfileId).ToArray();
                var currencyIds = context.UCommerceCurrency.Select(c => c.CurrencyId).ToArray();
                var orderNumberSeriesIds = context.UCommerceOrderNumberSerie.Select(c => c.OrderNumberId).ToArray();
                p.Report(0.1);
                var stores =
                    GeneratorHelper.Generate(() => GenerateStore(currencyIds, definitionIds, emailProfileIds, orderNumberSeriesIds), Count).ToList();
                p.Report(0.5);
                context.BulkInsert(stores, options => options.SetOutputIdentity = true);
                return stores;
            }
        }

        private UCommerceProductCatalogGroup GenerateStore(int[] currencyIds, int[] definitionIds,
            int[] emailProfileIds, int[] orderNumberSeriesIds)
        {
            return _storeFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.CurrencyId, f => f.PickRandom(currencyIds))
                .RuleFor(x => x.EmailProfileId, f => f.PickRandom(emailProfileIds))
                .RuleFor(x => x.OrderNumberId, f => f.PickRandom(orderNumberSeriesIds))
                .Generate();
        }

    }
}