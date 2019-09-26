using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class CatalogSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceProductCatalog> _catalogFaker;
        private readonly Faker<UCommerceProductCatalogDescription> _descriptionFaker;
        private readonly Faker _faker;

        public CatalogSeedingTask(uint count) : base(count)
        {
            _faker = new Faker();
            _catalogFaker = new Faker<UCommerceProductCatalog>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Product()}")
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent());

            _descriptionFaker = new Faker<UCommerceProductCatalogDescription>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.DisplayName, f => f.Commerce.ProductName());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.Catalog).Select(c => c.DefinitionId)
                .ToArray();

            var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
            var priceGroupIds = context.UCommercePriceGroup.Select(x => x.PriceGroupId).ToArray();

            var catalogs = await GenerateCatalogs(context, definitionIds, priceGroupIds);
            await GenerateDescriptions(context, catalogs, languageCodes);
            await GenerateProperties(context, definitionIds, catalogs, languageCodes);
            await GenerateAllowedPriceGroups(context, catalogs, priceGroupIds);
        }

        private async Task GenerateAllowedPriceGroups(UmbracoDbContext context, UCommerceProductCatalog[] catalogs,
            int[] priceGroupIds)
        {
            Console.Write($"Generating allowed price groups for {Count:N0} catalogs. ");
            using (var p = new ProgressBar())
            {
                uint batchSize = 100_000;
                uint numberOfBatches = 1 + (uint) catalogs.Length * (uint) priceGroupIds.Length / batchSize;
                var allowedPriceGroupBatches = catalogs.SelectMany(catalog =>
                    priceGroupIds.Select(priceGroupId =>
                        _faker.Random.Bool()
                            ? new UCommerceProductCatalogPriceGroupRelation
                                {PriceGroupId = priceGroupId, ProductCatalogId = catalog.ProductCatalogId}
                            : null
                    )
                        .Compact()).Batch(batchSize);
                await allowedPriceGroupBatches.EachWithIndexAsync(async (allowedPriceGroups, index) =>
                {
                    await context.BulkInsertAsync(allowedPriceGroups, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private async Task GenerateProperties(UmbracoDbContext context, int[] definitionIds,
            UCommerceProductCatalog[] catalogs,
            string[] languageCodes)
        {
            Console.Write($"Generating properties for {Count:N0} catalogs...");
            using (var p = new ProgressBar())
            {
                var mediaIds = GetAllMediaIds(context);
                var contentIds = GetAllContentIds(context);
                var definitionFields = LookupDefinitionFields(context, definitionIds);
                uint batchSize = 100_000;
                uint numberOfBatches = (uint) (1 + batchSize / definitionFields.Average(x => x.Count()) / catalogs.Length);
                
                var propertiyBatches = catalogs
                    .Where(catalog => catalog.DefinitionId.HasValue)
                    // ReSharper disable once PossibleInvalidOperationException
                    .SelectMany(category => definitionFields[category.DefinitionId.Value].SelectMany(field =>
                        AddEntityProperty(category.Guid, field.Field, languageCodes, mediaIds,
                            contentIds, field.Editor, field.Enums)))
                    .Batch(batchSize);

                await propertiyBatches.EachWithIndexAsync(async (properties, index) =>
                {
                    await context.BulkInsertAsync(properties, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private async Task GenerateDescriptions(UmbracoDbContext context, UCommerceProductCatalog[] catalogs,
            string[] languageCodes)
        {
            Console.Write($"Generating {(catalogs.Length * languageCodes.Length):N0} descriptions for {Count:N0} catalogs. ");
            using (var p = new ProgressBar())
            {
                uint batchSize = 100_000;
                uint numberOfBatches = (uint) (catalogs.Length * languageCodes.Length) / batchSize;
                var descriptionBatches = catalogs.SelectMany(catalog =>
                    languageCodes.Select(language => _descriptionFaker
                        .RuleFor(x => x.CultureCode, f => language)
                        .RuleFor(x => x.ProductCatalogId, f => catalog.ProductCatalogId)
                        .Generate()
                    )).Batch(batchSize);

                await descriptionBatches.EachWithIndexAsync(async (descriptions, index) =>
                {
                    await context.BulkInsertAsync(descriptions, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private async Task<UCommerceProductCatalog[]> GenerateCatalogs(UmbracoDbContext context, int[] definitionIds,
            int[] priceGroupIds)
        {
            Console.Write($"Generating {Count:N0} catalogs. ");
            using (var p = new ProgressBar())
            {
                var storeIds = context.UCommerceProductCatalogGroup.Select(c => c.ProductCatalogGroupId).ToArray();
                var catalogs =
                    GeneratorHelper.Generate(() => GenerateCatalog(definitionIds, storeIds, priceGroupIds), Count)
                        .DistinctBy(a => a.UniqueIndex())
                        .ToArray();

                p.Report(0.5);
                await context.BulkInsertAsync(catalogs);
                return catalogs;
            }
        }


        private UCommerceProductCatalog GenerateCatalog(int[] definitionIds, int[] storeIds, int[] priceGroupIds)
        {
            return _catalogFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.ProductCatalogGroupId, f => f.PickRandom(storeIds))
                .RuleFor(x => x.PriceGroupId, f => f.PickRandom(priceGroupIds))
                .Generate();
        }

        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(
                new RawSqlString($"TRUNCATE TABLE [Ucommerce_ProductCatalog]"));
        }
    }
}