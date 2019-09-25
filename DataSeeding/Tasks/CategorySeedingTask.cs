using System;
using System.Collections.Generic;
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
    public class CategorySeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceCategory> _categoryFaker;
        private readonly Faker<UCommerceCategoryProperty> _categoryPropertyFaker;
        private readonly Faker<UCommerceCategoryDescription> _descriptionFaker;
        private readonly Faker _faker;

        public CategorySeedingTask(uint count) : base(count)
        {
            _faker = new Faker();
            _categoryFaker = new Faker<UCommerceCategory>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.ProductMaterial()} {f.Commerce.Product()}")
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent());

            _categoryPropertyFaker = new Faker<UCommerceCategoryProperty>()
                .RuleFor(x => x.Guid, f => f.Random.Guid());

            _descriptionFaker = new Faker<UCommerceCategoryDescription>()
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.DisplayName, f => f.Commerce.Product())
                .RuleFor(x => x.RenderAsContent, f => f.Random.Bool(0.75f));
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var catalogIds = context.UCommerceProductCatalog.Select(c => c.ProductCatalogId).ToArray();
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.Category).Select(c => c.DefinitionId)
                .ToArray();
            var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
            var mediaIds = GetAllMediaIds(context);

            var topLevelCategories = await GenerateCategories(context, definitionIds, catalogIds, mediaIds);

            var secondLevelCategories =
                await GenerateSubCategories(context, definitionIds, mediaIds, topLevelCategories);

            var categories = topLevelCategories.Concat(secondLevelCategories).ToArray();

            await GenerateDescriptions(context, categories, languageCodes);

            await GenerateProperties(context, definitionIds, categories, languageCodes, mediaIds);
        }

        private async Task<IEnumerable<UCommerceCategory>> GenerateSubCategories(UmbracoDbContext context,
            int[] definitionIds, Guid[] mediaIds, UCommerceCategory[] topLevelCategories)
        {
            Console.Write($"Generating {4 * Count / 5:N0} subcategories. ");
            using (var p = new ProgressBar())
            {
                var categories = GeneratorHelper
                    .Generate(() => GenerateSubCategory(definitionIds, mediaIds, topLevelCategories), 4 * Count / 5)
                    .DistinctBy(a => a.UniqueIndex())
                    .ToArray();
                p.Report(0.5);
                await context.BulkInsertAsync(categories);
                return categories;
            }
        }

        private async Task GenerateProperties(UmbracoDbContext context, int[] definitionIds,
            UCommerceCategory[] categories,
            string[] languageCodes, Guid[] mediaIds)
        {
            var definitionFields = LookupDefinitionFields(context, definitionIds);
            uint estimatedPropertyCount = (uint) definitionFields.Average(x => x.Count()) * (uint) categories.Length;
            uint batchSize = 1_000_000;
            uint numberOfBatches = 1 + estimatedPropertyCount / batchSize;

            Console.Write($"Generating ~{estimatedPropertyCount:N0} properties for {categories.Length:N0} categories. ");
            using (var p = new ProgressBar())
            {
                var contentIds = GetAllContentIds(context);

                var propertyBatches = categories.SelectMany(category =>
                        definitionFields[category.DefinitionId].SelectMany(field =>
                            AddCategoryProperty(category.CategoryId, field.Field, languageCodes,
                                mediaIds, contentIds, field.Editor, field.Enums)))
                    .Batch(batchSize);

                await propertyBatches.EachWithIndexAsync(async (properties, index) =>
                {
                    await context.BulkInsertAsync(properties, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private async Task GenerateDescriptions(UmbracoDbContext context, UCommerceCategory[] categories,
            string[] languageCodes)
        {
            uint batchSize = 1_000_000;
            uint numberOfBatches = (uint) categories.Length * (uint) languageCodes.Length / batchSize; 
            Console.Write($"Generating {categories.Length * languageCodes.Length:N0} descriptions for {categories.Length:N0} categories. ");
            using (var p = new ProgressBar())
            {
                var descriptionBatches = categories.SelectMany(category =>
                    languageCodes.Select(language => _descriptionFaker
                        .RuleFor(x => x.CultureCode, f => language)
                        .RuleFor(x => x.CategoryId, f => category.CategoryId)
                        .Generate()
                    )).Batch(batchSize);

                await descriptionBatches.EachWithIndexAsync(async (descriptions, index) =>
                {
                    await context.BulkInsertAsync(descriptions, options => options.AutoMapOutputDirection = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private async Task<UCommerceCategory[]> GenerateCategories(UmbracoDbContext context, int[] definitionIds,
            int[] catalogIds, Guid[] mediaIds)
        {
            Console.Write($"Generating {Count / 5:N0} top level categories. ");
            using (var p = new ProgressBar())
            {
                var categories = GeneratorHelper
                    .Generate(() => GenerateCategory(definitionIds, catalogIds, mediaIds), Count / 5)
                    .DistinctBy(a => a.UniqueIndex())
                    .ToArray();
                p.Report(0.5);
                await context.BulkInsertAsync(categories);
                return categories;
            }
        }

        private IEnumerable<UCommerceCategoryProperty> AddCategoryProperty(int categoryId,
            UCommerceDefinitionField field, string[] languageCodes, Guid[] mediaIds, Guid[] contentIds, string editor,
            Guid[] enumGuids)
        {
            if (field.Multilingual)
            {
                return languageCodes.Select(languageCode =>
                {
                    return _categoryPropertyFaker
                        .RuleFor(x => x.DefinitionFieldId, f => field.DefinitionFieldId)
                        .RuleFor(x => x.CategoryId, f => categoryId)
                        .RuleFor(x => x.CultureCode, f => languageCode)
                        .RuleFor(x => x.Value, f => BogusProperty.BogusValue(mediaIds, contentIds, editor, enumGuids))
                        .Generate();
                });
            }
            else
            {
                return new[]
                {
                    _categoryPropertyFaker
                        .RuleFor(x => x.DefinitionFieldId, f => field.DefinitionFieldId)
                        .RuleFor(x => x.CategoryId, f => categoryId)
                        .RuleFor(x => x.CultureCode, f => null)
                        .RuleFor(x => x.Value, f => BogusProperty.BogusValue(mediaIds, contentIds, editor, enumGuids))
                        .Generate()
                };
            }
        }

        private UCommerceCategory GenerateCategory(int[] definitionIds, int[] catalogIds, Guid[] mediaIds)
        {
            return _categoryFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.ProductCatalogId, f => f.PickRandom(catalogIds))
                .RuleFor(x => x.ImageMediaId, f => f.PickRandom(mediaIds).ToString())
                .Generate();
        }

        private UCommerceCategory GenerateSubCategory(int[] definitionIds, Guid[] mediaIds, UCommerceCategory[] parentCategories)
        {
            var parentCategory = _faker.PickRandom(parentCategories);
            return _categoryFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.ProductCatalogId, f => parentCategory.ProductCatalogId)
                .RuleFor(x => x.ImageMediaId, f => f.PickRandom(mediaIds).ToString())
                .RuleFor(x => x.ParentCategoryId, f => parentCategory.CategoryId)
                .Generate();
        }

        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(new RawSqlString($"TRUNCATE TABLE [Ucommerce_Category]"));
        }
    }
}