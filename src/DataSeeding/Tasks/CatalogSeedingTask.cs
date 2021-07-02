using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.DataSeeding.Tasks.Cms;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class CatalogSeedingTask : DataSeedingTaskBase
    {
        private readonly ICmsContent _cmsContent;
        private readonly Faker<UCommerceProductCatalog> _catalogFaker;
        private readonly Faker<UCommerceProductCatalogDescription> _descriptionFaker;
        private readonly Faker _faker;

        public CatalogSeedingTask(uint count, ICmsContent cmsContent) : base(count)
        {
            _cmsContent = cmsContent;
            _faker = new Faker();
            _catalogFaker = new Faker<UCommerceProductCatalog>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Product()}")
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ShowPricesIncludingVat, f => f.Random.Bool())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent())
                .RuleFor(x => x.DisplayOnWebSite, f => f.Random.Bool(0.95f));

            _descriptionFaker = new Faker<UCommerceProductCatalogDescription>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.DisplayName, f => f.Commerce.ProductName());
        }

        public override void Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.Catalog).Select(c => c.DefinitionId)
                .ToArray();

            var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
            var priceGroupIds = context.UCommercePriceGroup.Select(x => x.PriceGroupId).ToArray();

            var catalogs = GenerateCatalogs(context, definitionIds, priceGroupIds);
            GenerateDescriptions(context, catalogs, languageCodes);
            GenerateProperties(context, definitionIds, catalogs, languageCodes);
            GenerateAllowedPriceGroups(context, catalogs, priceGroupIds);
        }

        private void GenerateAllowedPriceGroups(UmbracoDbContext context, IEnumerable<UCommerceProductCatalog> catalogs,
            int[] priceGroupIds)
        {
            Console.Write($"Generating allowed price groups for {Count:N0} catalogs. ");
            using (var p = new ProgressBar())
            {
                uint batchSize = 100_000;
                uint numberOfBatches =
                    (uint) Math.Ceiling(1.0 * catalogs.Count() * (uint) priceGroupIds.Length / batchSize);
                var allowedPriceGroupBatches = catalogs.SelectMany(catalog =>
                    priceGroupIds.Select(priceGroupId =>
                            _faker.Random.Bool()
                                ? new UCommerceProductCatalogPriceGroupRelation
                                {
                                    PriceGroupId = priceGroupId, ProductCatalogId = catalog.ProductCatalogId,
                                    Guid = _faker.Random.Guid()
                                }
                                : null
                        )
                        .Compact()).Batch(batchSize);

                allowedPriceGroupBatches.EachWithIndex((allowedPriceGroups, index) =>
                {
                    context.BulkInsert(allowedPriceGroups.ToList(), options => options.SetOutputIdentity = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private void GenerateProperties(UmbracoDbContext context, int[] definitionIds,
            IEnumerable<UCommerceProductCatalog> catalogs,
            string[] languageCodes)
        {
            Console.Write($"Generating properties for {Count:N0} catalogs...");
            using (var p = new ProgressBar())
            {
                var mediaIds = _cmsContent.GetAllMediaIds(context);
                var contentIds = _cmsContent.GetAllContentIds(context);
                var definitionFields = LookupDefinitionFields(context, definitionIds);
                uint batchSize = 100_000;
                uint numberOfBatches = definitionFields.Any()
                    ? (uint) Math.Ceiling (
                        1.0 * batchSize / definitionFields.Average(x => x.Count()) / catalogs.Count())
                    : 1;

                var propertiyBatches = catalogs
                    .Where(catalog => catalog.DefinitionId.HasValue)
                    // ReSharper disable once PossibleInvalidOperationException
                    .SelectMany(category => definitionFields[category.DefinitionId.Value].SelectMany(field =>
                        AddEntityProperty(category.Guid, field.Field, languageCodes, mediaIds,
                            contentIds, field.Editor, field.Enums)))
                    .Batch(batchSize);

                propertiyBatches.EachWithIndex((properties, index) =>
                {
                    context.BulkInsert(properties.ToList(), options => options.SetOutputIdentity = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private void GenerateDescriptions(UmbracoDbContext context, IEnumerable<UCommerceProductCatalog> catalogs,
            string[] languageCodes)
        {
            Console.Write(
                $"Generating {(catalogs.Count() * languageCodes.Length):N0} descriptions for {Count:N0} catalogs. ");
            using (var p = new ProgressBar())
            {
                uint batchSize = 100_000;
                uint numberOfBatches = (uint) Math.Ceiling(1.0 * catalogs.Count() * languageCodes.Length / batchSize);
                var descriptionBatches = catalogs.SelectMany(catalog =>
                    languageCodes.Select(language => _descriptionFaker
                        .RuleFor(x => x.CultureCode, f => language)
                        .RuleFor(x => x.ProductCatalogId, f => catalog.ProductCatalogId)
                        .Generate()
                    )).Batch(batchSize);

                descriptionBatches.EachWithIndex((descriptions, index) =>
                {
                    context.BulkInsert(descriptions.ToList(), options => options.SetOutputIdentity = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private List<UCommerceProductCatalog> GenerateCatalogs(UmbracoDbContext context, int[] definitionIds,
            int[] priceGroupIds)
        {
            Console.Write($"Generating {Count:N0} catalogs. ");
            using (var p = new ProgressBar())
            {
                var storeIds = context.UCommerceProductCatalogGroup.Select(c => c.ProductCatalogGroupId).ToArray();
                var catalogs =
                    GeneratorHelper.Generate(() => GenerateCatalog(definitionIds, storeIds, priceGroupIds), Count)
                        .DistinctBy(a => a.UniqueIndex())
                        .ToList();

                p.Report(0.5);
                context.BulkInsert(catalogs, options => options.SetOutputIdentity = true);
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
    }
}