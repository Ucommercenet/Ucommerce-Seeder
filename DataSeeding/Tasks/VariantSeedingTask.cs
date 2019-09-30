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

        public override async Task Seed(UmbracoDbContext context)
        {
            var productDefinitionIds = context.UCommerceProductDefinition.Select(x => x.ProductDefinitionId).ToArray();
            var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
            var productDefinitionFields = LookupProductDefinitionFields(context, true);
            var priceGroupIds = context.UCommercePriceGroup.Select(pg => pg.PriceGroupId).ToArray();
            var productIds = context.UCommerceProduct.Select(product => product.ProductId).ToArray();
            var mediaIds = _cmsContent.GetAllMediaIds(context);
            var contentIds = _cmsContent.GetAllMediaIds(context);

            var products = await GenerateVariants(context, productDefinitionIds, languageCodes, productIds, mediaIds);

            await GenerateDescriptions(context, languageCodes, products);

            await GenerateProperties(context, products, productDefinitionFields, mediaIds, contentIds);

            await GeneratePrices(context, priceGroupIds, products);
        }
        
        protected async Task<UCommerceProduct[]> GenerateVariants(UmbracoDbContext context, int[] productDefinitionIds,
            string[] languageCodes, int[] productIds, Guid[] mediaIds)
        {
            Console.Write($"Generating {Count:N0} {EntityNamePlural}. ");
            using (var p = new ProgressBar())
            {
                var variants =
                    GeneratorHelper.Generate(() => GenerateProduct(productDefinitionIds, languageCodes, mediaIds),
                        Count).ToArray();

                p.Report(0.33);
                foreach (var variant in variants)
                {
                    variant.VariantSku = _faker.Commerce.Ean8();
                    variant.ParentProductId = _faker.PickRandom(productIds);
                }

                p.Report(0.66);
                await context.BulkInsertAsync(variants, options => options.BatchSize = 100_000);
                return variants;
            }
        }
    }
}