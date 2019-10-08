using System;
using System.Linq;
using System.Threading.Tasks;
using Ucommerce.Seeder.DataSeeding.Tasks.Cms;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class VariantSeedingTask : ProductSeedingTask
    {
        private readonly ICmsContent _cmsContent;

        public VariantSeedingTask(DatabaseSize databaseSize, ICmsContent cmsContent) : base(databaseSize, cmsContent)
        {
            _cmsContent = cmsContent;
        }

        protected override string EntityNamePlural
        {
            get => "variants";
        }

        public override uint Count
        {
            get => _databaseSize.AverageVariantsPerProduct * _databaseSize.Products;
        }

        public class ProductWithDefinition
        {
            public int ProductId { get; set; }
            public int ProductDefinitionId { get; set; }
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
            var productDefinitionFields = LookupProductDefinitionFields(context, true);
            var priceGroupIds = context.UCommercePriceGroup.Select(pg => pg.PriceGroupId).ToArray();
            
            var productFamilyIds = context.UCommerceProduct
                .Where(p => p.ProductDefinition.UCommerceProductDefinitionField.Any(f => f.IsVariantProperty)) // pick families only
                .Where(p => p.ParentProductId == null) // don't pick variants
                .Select(product => new ProductWithDefinition {ProductId = product.ProductId, ProductDefinitionId = product.ProductDefinitionId})
                .ToArray();
            
            var mediaIds = _cmsContent.GetAllMediaIds(context);
            var contentIds = _cmsContent.GetAllMediaIds(context);

            var products = await GenerateVariants(context, productFamilyIds, mediaIds);

            await GenerateDescriptions(context, languageCodes, products);

            await GenerateProperties(context, products, productDefinitionFields, mediaIds, contentIds);

            await GeneratePrices(context, priceGroupIds, products);
        }

        protected async Task<UCommerceProduct[]> GenerateVariants(UmbracoDbContext context, ProductWithDefinition[] products, string[] mediaIds)
        {
            Console.Write($"Generating {Count:N0} {EntityNamePlural}. ");
            using (var p = new ProgressBar())
            {
                var variants =
                    GeneratorHelper.Generate(() => GenerateVariant(mediaIds, products),
                        Count).ToArray();

                p.Report(0.5);
                await context.BulkInsertAsync(variants, options => options.BatchSize = 100_000);
                return variants;
            }
        }

        private UCommerceProduct GenerateVariant(string[] mediaIds, ProductWithDefinition[] products)
        {
            var productFamily = _faker.PickRandom(products);
            var product = _productFaker
                .RuleFor(x => x.ParentProductId, f => productFamily.ProductId)
                .RuleFor(x => x.ProductDefinitionId, f => productFamily.ProductDefinitionId)
                .RuleFor(x => x.PrimaryImageMediaId, f => f.PickRandomOrDefault(mediaIds))
                .RuleFor(x => x.ThumbnailImageMediaId, f => f.PickRandomOrDefault(mediaIds))
                .RuleFor(x => x.VariantSku, f => f.Commerce.Ean8())
                .Generate();

            return product;

        }
    }
}