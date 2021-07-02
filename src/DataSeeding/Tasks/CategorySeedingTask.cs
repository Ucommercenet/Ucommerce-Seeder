using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CategorySeedingTask : DataSeedingTaskBase
    {
        private readonly ICmsContent _cmsContent;
        private readonly Faker<UCommerceCategory> _categoryFaker;
        private readonly Faker<UCommerceCategoryProperty> _categoryPropertyFaker;
        private readonly Faker<UCommerceCategoryDescription> _descriptionFaker;
        private readonly Faker _faker;

        public CategorySeedingTask(uint count, ICmsContent cmsContent) : base(count)
        {
            _cmsContent = cmsContent;
            _faker = new Faker();
            _categoryFaker = new Faker<UCommerceCategory>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.ProductMaterial()}")
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.DisplayOnSite, f => f.Random.Bool(0.85f))
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent());

            _categoryPropertyFaker = new Faker<UCommerceCategoryProperty>()
                .RuleFor(x => x.Guid, f => f.Random.Guid());

            _descriptionFaker = new Faker<UCommerceCategoryDescription>()
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.RenderAsContent, f => f.Random.Bool(0.75f));
        }

        public override void Seed(UmbracoDbContext context)
        {
            var catalogIds = context.UCommerceProductCatalog.Select(c => c.ProductCatalogId).ToArray();
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.Category).Select(c => c.DefinitionId)
                .ToArray();
            var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
            var mediaIds = _cmsContent.GetAllMediaIds(context);

            var topLevelCategories = GenerateCategories(context, definitionIds, catalogIds, mediaIds);

            var secondLevelCategories =
                GenerateSubCategories(context, definitionIds, mediaIds, topLevelCategories);

            var categories = topLevelCategories.Concat(secondLevelCategories).ToList();

            GenerateDescriptions(context, categories, languageCodes);

            GenerateProperties(context, definitionIds, categories, languageCodes, mediaIds);
        }


        private void GenerateProperties(UmbracoDbContext context, int[] definitionIds,
            IEnumerable<UCommerceCategory> categories,
            string[] languageCodes, string[] mediaIds)
        {
            var definitionFields = LookupDefinitionFields(context, definitionIds);
            uint estimatedPropertyCount = definitionFields.Any()
                ? (uint) definitionFields.Average(x => x.Count()) * (uint) categories.Count()
                : 1;
            uint batchSize = 1_000_000;
            uint numberOfBatches = (uint) Math.Ceiling(1.0 * estimatedPropertyCount / batchSize);

            Console.Write(
                $"Generating ~{estimatedPropertyCount:N0} properties for {categories.Count():N0} categories. ");
            using (var p = new ProgressBar())
            {
                var contentIds = _cmsContent.GetAllContentIds(context);

                var propertyBatches = categories.SelectMany(category =>
                        definitionFields[category.DefinitionId].SelectMany(field =>
                            AddCategoryProperty(category.CategoryId, field.Field, languageCodes,
                                mediaIds, contentIds, field.Editor, field.Enums)))
                    .Batch(batchSize);

                propertyBatches.EachWithIndex((properties, index) =>
                {
                    context.BulkInsert(properties.ToList(), options => options.SetOutputIdentity = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private void GenerateDescriptions(UmbracoDbContext context, IEnumerable<UCommerceCategory> categories,
            string[] languageCodes)
        {
            uint batchSize = 100_000;
            uint numberOfBatches =
                (uint) Math.Ceiling(1.0 * categories.Count() * (uint) languageCodes.Length / batchSize);
            Console.Write(
                $"Generating {categories.Count() * languageCodes.Length:N0} descriptions for {categories.Count():N0} categories in batches of {batchSize:N0}. ");
            using (var p = new ProgressBar())
            {
                var descriptionBatches = categories.SelectMany(category =>
                    languageCodes.Select(language => _descriptionFaker
                        .RuleFor(x => x.CultureCode, f => language)
                        .RuleFor(x => x.CategoryId, f => category.CategoryId)
                        .RuleFor(x => x.DisplayName, f => $"{category.Name} {f.Commerce.Product()}")
                        .Generate()
                    )).Batch(batchSize);

                descriptionBatches.EachWithIndex((descriptions, index) =>
                {
                    context.BulkInsert(descriptions.ToList(), options => options.SetOutputIdentity = false);
                    p.Report(1.0 * index / numberOfBatches);
                });
            }
        }

        private List<UCommerceCategory> GenerateCategories(UmbracoDbContext context, int[] definitionIds,
            int[] catalogIds, string[] mediaIds)
        {
            uint batchSize = 100_000;
            uint numberOfBatches = (uint) Math.Ceiling(1.0 * Count / 5 / batchSize);
            Console.Write($"Generating {Count / 5:N0} top level categories in batches of {batchSize:N0}. ");
            var insertedCategories = new List<UCommerceCategory>((int) Count / 5);
            using (var p = new ProgressBar())
            {
                var categoryBatches = GeneratorHelper
                    .Generate(() => GenerateCategory(definitionIds, catalogIds, mediaIds), Count / 5)
                    .DistinctBy(a => a.UniqueIndex())
                    .Batch(batchSize);

                categoryBatches.EachWithIndex((categories, index) =>
                {
                    var listOfCats = categories.ToList();
                    context.BulkInsert(listOfCats, options => options.SetOutputIdentity = true);
                    insertedCategories.AddRange(listOfCats);
                    p.Report(1.0 * index / numberOfBatches);
                });

                return insertedCategories;
            }
        }

        private List<UCommerceCategory> GenerateSubCategories(UmbracoDbContext context,
            int[] definitionIds, string[] mediaIds, IEnumerable<UCommerceCategory> topLevelCategories)
        {
            uint batchSize = 100_000;
            uint numberOfBatches = (uint) Math.Ceiling( 4.0 * Count / 5.0 / batchSize);
            Console.Write($"Generating {4 * Count / 5:N0} subcategories in batches of {batchSize}. ");
            var insertedCategories = new List<UCommerceCategory>((int) Count / 5);
            using (var p = new ProgressBar())
            {
                var categoryBatches = GeneratorHelper
                    .Generate(() => GenerateSubCategory(definitionIds, mediaIds, topLevelCategories), 4 * Count / 5)
                    .DistinctBy(a => a.UniqueIndex())
                    .Batch(batchSize);

                categoryBatches.EachWithIndex((categories, index) =>
                {
                    var listOfCats = categories.ToList();
                    context.BulkInsert(listOfCats, options => options.SetOutputIdentity = true);
                    insertedCategories.AddRange(listOfCats);
                    p.Report(1.0 * index / numberOfBatches);
                });

                return insertedCategories;
            }
        }

        private List<UCommerceCategoryProperty> AddCategoryProperty(int categoryId,
            UCommerceDefinitionField field, string[] languageCodes, string[] mediaIds, string[] contentIds,
            string editor,
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
                }).ToList();
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
                }.ToList();
            }
        }

        private UCommerceCategory GenerateCategory(int[] definitionIds, int[] catalogIds, string[] mediaIds)
        {
            return _categoryFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.ProductCatalogId, f => f.PickRandom(catalogIds))
                .RuleFor(x => x.ImageMediaId, f => f.PickRandomOrDefault(mediaIds))
                .Generate();
        }

        private UCommerceCategory GenerateSubCategory(int[] definitionIds, string[] mediaIds,
            IEnumerable<UCommerceCategory> parentCategories)
        {
            var parentCategory = _faker.PickRandom(parentCategories);

            if (parentCategory.CategoryId == 0)
            {
                throw new InvalidOperationException("Parent category must have an Id.");
            }

            return _categoryFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.ProductCatalogId, f => parentCategory.ProductCatalogId)
                .RuleFor(x => x.ImageMediaId, f => f.PickRandomOrDefault(mediaIds))
                .RuleFor(x => x.ParentCategoryId, f => parentCategory.CategoryId)
                .Generate();
        }
    }
}