using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;
using Z.BulkOperations;

// ReSharper disable ReplaceWithSingleCallToAny
// ReSharper disable ReplaceWithSingleCallToFirst

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class ProductSeedingTask : DataSeedingTaskBase
    {
        protected readonly DatabaseSize _databaseSize;
        protected readonly Faker _faker = new Faker();
        protected readonly Faker<UCommerceProduct> _productFaker;
        protected readonly Faker<UCommerceProductRelation> _productRelationFaker;
        protected readonly Faker<UCommercePrice> _priceFaker;
        protected readonly Faker<UCommerceProductPrice> _productPriceFaker;
        protected readonly Faker<UCommerceProductProperty> _productPropertyFaker;
        protected readonly Faker<UCommerceProductDescription> _productDescriptionFaker;
        protected readonly Faker<UCommerceProductDescriptionProperty> _productDescriptionPropertyFaker;

        public ProductSeedingTask(DatabaseSize databaseSize) : base(databaseSize.Products)
        {
            _databaseSize = databaseSize;
            _productFaker = new Faker<UCommerceProduct>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Rating, f => f.Random.Double(0, 10))
                .RuleFor(x => x.Sku, f => f.Commerce.Ean13())
                .RuleFor(x => x.Weight, f => f.Random.Decimal(0.1M, 1000M))
                .RuleFor(x => x.AllowOrdering, f => f.Random.Bool(0.9f))
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent())
                .RuleFor(x => x.DisplayOnSite, f => f.Random.Bool(0.85f));

            _productRelationFaker = new Faker<UCommerceProductRelation>()
                .RuleFor(x => x.Guid, f => f.Random.Guid());

            _priceFaker = new Faker<UCommercePrice>()
                .RuleFor(y => y.Amount, g => g.Finance.Amount())
                .RuleFor(y => y.Guid, g => g.Random.Guid());

            _productPriceFaker = new Faker<UCommerceProductPrice>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.MinimumQuantity, f => f.Random.Int(1, 1000));

            _productPropertyFaker = new Faker<UCommerceProductProperty>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Value, f => f.Random.Word());

            _productDescriptionFaker = new Faker<UCommerceProductDescription>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.DisplayName, f => f.Commerce.ProductName())
                .RuleFor(x => x.LongDescription, f => f.Lorem.Sentences(3))
                .RuleFor(x => x.ShortDescription, f => f.Lorem.Sentence());

            _productDescriptionPropertyFaker = new Faker<UCommerceProductDescriptionProperty>()
                .RuleFor(x => x.Guid, f => f.Random.Guid());
        }

        protected virtual string EntityNamePlural
        {
            get => "products";
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var productDefinitionIds = context.UCommerceProductDefinition.Select(x => x.ProductDefinitionId).ToArray();
            var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
            var productDefinitionFields = LookupProductDefinitionFields(context, false);
            var priceGroupIds = context.UCommercePriceGroup.Select(pg => pg.PriceGroupId).ToArray();
            var productRelationTypeIds =
                context.UCommerceProductRelationType.Select(prt => prt.ProductRelationTypeId).ToArray();
            var mediaIds = GetAllMediaIds(context);
            var contentIds = GetAllMediaIds(context);

            var products = await GenerateProducts(context, productDefinitionIds, languageCodes, mediaIds);

            await GenerateDescriptions(context, languageCodes, products);

            await GenerateProperties(context, products, productDefinitionFields, mediaIds,
                contentIds);

            await GeneratePrices(context, priceGroupIds, products);

            await GenerateRelations(context, products, productRelationTypeIds);
        }

        private async Task GenerateRelations(UmbracoDbContext context, UCommerceProduct[] products,
            int[] productRelationTypeIds)
        {
            Console.Write(
                $"Generating {_databaseSize.ProductRelationsPerProduct * Count:N0} relations for {Count:N0} {EntityNamePlural}. ");
            using (var p = new ProgressBar())
            {
                uint batchSize = 100_000;
                uint numberOfBatches = 1 + _databaseSize.ProductRelationsPerProduct * Count / batchSize;
                
                var relationBatches = products.SelectMany(product => Enumerable.Range(1,
                        (int) _databaseSize.ProductRelationsPerProduct).Select(i =>
                    {
                        var otherProduct = _faker.PickRandom(products);
                        if (otherProduct != product)
                        {
                            return GenerateProductRelation(product.ProductId, otherProduct.ProductId,
                                productRelationTypeIds);
                        }

                        return null;
                    }))
                    .Compact()
                    .DistinctBy(a => a.UniqueIndex())
                    .Batch(batchSize);

                await relationBatches.EachWithIndexAsync(async (relations, index) =>
                {
                    await context.BulkInsertAsync(relations, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        protected async Task GeneratePrices(UmbracoDbContext context, int[] priceGroupIds,
            UCommerceProduct[] products)
        {
            ulong totalCount = Count * (ulong) priceGroupIds.Length * _databaseSize.TiersPerPriceGroup;
            uint batchSize = 1_00_000;

            Console.Write(
                $"Generating {totalCount:N0} prices in batches of {batchSize:N0}. ");
            using (var p = new ProgressBar())
            {
                var priceBatches = products
                    .SelectMany(product =>
                        priceGroupIds.SelectMany(priceGroupId =>
                            Enumerable.Range(1, (int) _databaseSize.TiersPerPriceGroup)
                                .Select(i => GeneratePrice(priceGroupId))
                        )
                    ).Batch(batchSize);

                var productBatches = products
                    .SelectMany(product =>
                        priceGroupIds.SelectMany(priceGroupId =>
                            Enumerable.Range(1, (int) _databaseSize.TiersPerPriceGroup)
                                .Select(i => new
                                    {Product = product, Tier = i })
                        )
                    ).Batch(batchSize);

                ulong numBatches = 2 * totalCount / batchSize + 1;
                uint batchCount = 0;
                foreach (var batch in priceBatches.Zip(productBatches, (prices, moreInfo) => new {prices, moreInfo}))
                {
                    var prices = batch.prices.ToArray();
                    await context.BulkInsertAsync(prices,
                        options =>
                        {
                            options.AutoMapOutputDirection = true;
                        });

                    p.Report(1.0 * ++batchCount / numBatches);

                    var productPrices = prices.Zip(batch.moreInfo,
                        (price, product) => new {price, product}).Select(zippedBatch =>
                        GenerateProductPrice(zippedBatch.price.PriceId, zippedBatch.product.Product.ProductId,
                            zippedBatch.product.Tier)).ToArray();

                    await context.BulkInsertAsync(productPrices,
                        options =>
                        {
                            options.AutoMapOutputDirection = false;
                            // Specifying the columns to insert is necessary for this table only.
                            // The reason is unknown, but if you omit it, MinimumQuantity will always be '1'.
                            options.ColumnInputExpression = x => new { x.MinimumQuantity, x.Guid, x.ProductId, x.PriceId };
                        });

                    p.Report(1.0 * ++batchCount / numBatches);
                }
            }
        }

        protected async Task GenerateDescriptions(UmbracoDbContext context,
            string[] languageCodes, UCommerceProduct[] products)
        {
            Console.Write(
                $"Generating {(Count * languageCodes.Length):N0} descriptions for {Count:N0} {EntityNamePlural} with  {languageCodes.Length:N0} languages. ");
            using (var p = new ProgressBar())
            {
                uint batchSize = 1_000_000;
                uint estimatedBatchCount = 1 + Count * (uint) languageCodes.Length / batchSize;
                var descriptionBatches = products.SelectMany(product =>
                    languageCodes.Select(language => GenerateDescription(product.ProductId, language))
                ).Batch(batchSize);

                await descriptionBatches.EachWithIndexAsync(async (descriptions, index) =>
                    {
                        await context.BulkInsertAsync(descriptions);
                        p.Report(1.0 * index / estimatedBatchCount);
                    }
                );
            }
        }

        protected async Task GenerateProperties(UmbracoDbContext context, UCommerceProduct[] products,
            ILookup<int, ProductDefinitionFieldEditorAndEnum> productDefinitionFields, Guid[] mediaIds,
            Guid[] contentIds)
        {
            uint averageNumberOfFieldsPerProduct = (uint) productDefinitionFields.Average(f => f.Count()) / 2;
            uint batchSize = 1_000_000;
            uint estimatedBatchCount = 1 + Count * averageNumberOfFieldsPerProduct / batchSize;

            Console.Write(
                $"Generating ~{averageNumberOfFieldsPerProduct * products.Length:N0} language variant properties with values for {products.Length:N0} {EntityNamePlural}. ");

            using (var p = new ProgressBar())
            {
                ILookup<int, int> descriptions = context.UCommerceProductDescription
                    .Select(x => new {x.ProductId, x.ProductDescriptionId})
                    .ToLookup(x => x.ProductId, x => x.ProductDescriptionId);

                var languageVariantPropertyBatches = products.SelectMany(product =>
                        GenerateLanguageVariantProductProperties(descriptions[product.ProductId],
                            productDefinitionFields[product.ProductDefinitionId], mediaIds, contentIds))
                    .Batch(batchSize);

                await languageVariantPropertyBatches.EachWithIndexAsync(async (languageVariantProperties, index) =>
                {
                    await context.BulkInsertAsync(languageVariantProperties,
                        options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / estimatedBatchCount);
                });
            }

            Console.Write(
                $"Generating ~{averageNumberOfFieldsPerProduct * products.Length:N0} language invariant properties with values for {products.Length:N0} {EntityNamePlural}. ");
            using (var p = new ProgressBar())
            {
                var simplePropertyBatches = products.SelectMany(product =>
                        GenerateLanguageInvariantProductProperties(product.ProductId,
                            productDefinitionFields[product.ProductDefinitionId], mediaIds, contentIds))
                    .Batch(batchSize);

                await simplePropertyBatches.EachWithIndexAsync(async (simpleProperties, index) =>
                {
                    await context.BulkInsertAsync(simpleProperties, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / estimatedBatchCount);
                });
            }
        }

        protected async Task<UCommerceProduct[]> GenerateProducts(UmbracoDbContext context, int[] productDefinitionIds,
            string[] languageCodes, Guid[] mediaIds)
        {
            Console.Write($"Generating {Count:N0} products. ");
            using (var p = new ProgressBar())
            {
                var products =
                    GeneratorHelper.Generate(() => GenerateProduct(productDefinitionIds, languageCodes, mediaIds),
                        Count);
                p.Report(0.5);
                await context.BulkInsertAsync(products);
                return products;
            }
        }

        protected static ILookup<int, ProductDefinitionFieldEditorAndEnum> LookupProductDefinitionFields(
            UmbracoDbContext context, bool variantProperties)
        {
            return context.UCommerceProductDefinitionField
                .Where(field => field.IsVariantProperty == variantProperties)
                .Select(field => new ProductDefinitionFieldEditorAndEnum(field,
                    field.DataType.Definition.UCommerceDefinitionField.Where(x => x.Name == "Editor").Any()
                        ? field.DataType.Definition.UCommerceDefinitionField.Where(x => x.Name == "Editor")
                            .First().UCommerceEntityProperty
                            .Where(x => x.EntityId == field.DataType.Guid)
                            .Select(x => x.Value).FirstOrDefault()
                        : "",
                    field.DataType.UCommerceDataTypeEnum.Select(x => x.Guid)))
                .ToLookup(field => field.Field.ProductDefinitionId);
        }

        protected UCommerceProductRelation GenerateProductRelation(int firstProductId, int otherProductId,
            int[] productRelationTypeIds)
        {
            return _productRelationFaker
                .RuleFor(x => x.ProductId, f => firstProductId)
                .RuleFor(x => x.RelatedProductId, f => otherProductId)
                .RuleFor(x => x.ProductRelationTypeId, f => f.PickRandom(productRelationTypeIds))
                .Generate();
        }


        protected UCommerceProductPrice GenerateProductPrice(int priceId, int productId, int tierNumber)
        {
            return _productPriceFaker
                .RuleFor(x => x.PriceId, f => priceId)
                .RuleFor(x => x.ProductId, f => productId)
                .RuleFor(x => x.MinimumQuantity, f => (int) Math.Pow(10, (tierNumber - 1)))
                .Generate();
        }

        protected UCommercePrice GeneratePrice(int priceGroupId)
        {
            return _priceFaker
                .RuleFor(x => x.PriceGroupId, f => priceGroupId)
                .Generate();
        }

        protected UCommerceProductDescriptionProperty[] GenerateLanguageVariantProductProperties(
            IEnumerable<int> descriptionIds,
            IEnumerable<ProductDefinitionFieldEditorAndEnum> fields, Guid[] mediaIds, Guid[] contentIds)
        {
            return fields
                .Where(field => field.Field.Multilingual)
                .SelectMany(field =>
                    descriptionIds.Select(descriptionId =>
                        _productDescriptionPropertyFaker
                            .RuleFor(x => x.ProductDefinitionFieldId, f => field.Field.ProductDefinitionFieldId)
                            .RuleFor(x => x.ProductDescriptionId, f => descriptionId)
                            .RuleFor(x => x.Value,
                                f => BogusProperty.BogusValue(mediaIds, contentIds, field.Editor, field.Enums))
                            .Generate()
                    )
                ).ToArray();
        }

        protected UCommerceProductProperty[] GenerateLanguageInvariantProductProperties(int productId,
            IEnumerable<ProductDefinitionFieldEditorAndEnum> fields, Guid[] mediaIds, Guid[] contentIds)
        {
            return fields
                .Where(field => !field.Field.Multilingual)
                .Select(field =>
                    _productPropertyFaker
                        .RuleFor(x => x.ProductDefinitionFieldId, f => field.Field.ProductDefinitionFieldId)
                        .RuleFor(x => x.ProductId, f => productId)
                        .RuleFor(x => x.Value,
                            f => BogusProperty.BogusValue(mediaIds, contentIds, field.Editor, field.Enums))
                        .Generate()).ToArray();
        }

        protected UCommerceProduct GenerateProduct(int[] productDefinitionIds, string[] languageCodes, Guid[] mediaIds)
        {
            var product = _productFaker
                .RuleFor(x => x.ProductDefinitionId, f => f.PickRandom(productDefinitionIds))
                .RuleFor(x => x.PrimaryImageMediaId, f => f.PickRandom(mediaIds).ToString())
                .RuleFor(x => x.ThumbnailImageMediaId, f => f.PickRandom(mediaIds).ToString())
                .Generate();

            return product;
        }

        protected UCommerceProductDescription GenerateDescription(int productId, string languageCode)
        {
            return _productDescriptionFaker
                .RuleFor(x => x.CultureCode, f => languageCode)
                .RuleFor(x => x.ProductId, f => productId)
                .Generate();
        }

        public override Task Truncate(UmbracoDbContext context)
        {
            string[] tables =
            {
                "TRUNCATE TABLE [Ucommerce_ProductRelation]",
                "TRUNCATE TABLE [Ucommerce_ProductDescriptionProperty]",
                "TRUNCATE TABLE [Ucommerce_ProductDescription]",
                "TRUNCATE TABLE [Ucommerce_ProductProperty]",
                "TRUNCATE TABLE [Ucommerce_ProductPrice]",
                "TRUNCATE TABLE [Ucommerce_Price]",
                "TRUNCATE TABLE [Ucommerce_Product]",
            };

            foreach (var sql in tables)
            {
                context.Database.ExecuteSqlCommand(new RawSqlString(sql));
            }

            return Task.CompletedTask;
        }
    }
}