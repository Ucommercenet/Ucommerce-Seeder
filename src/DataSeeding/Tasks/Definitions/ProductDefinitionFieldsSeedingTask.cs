using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Tasks.Cms;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class ProductDefinitionFieldsSeedingTask : DataSeedingTaskBase
    {
        private readonly ICmsContent _cmsContent;
        private readonly Faker<UCommerceProductDefinitionField> _productDefinitionFieldFaker;
        private readonly Faker<UCommerceProductDefinitionFieldDescription> _definitionFieldDescriptionFaker;

        public ProductDefinitionFieldsSeedingTask(uint count, ICmsContent cmsContent) : base(count)
        {
            _cmsContent = cmsContent;
            _productDefinitionFieldFaker = new Faker<UCommerceProductDefinitionField>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Multilingual, f => f.Random.Bool())
                .RuleFor(x => x.Name, f => $"{f.Commerce.Color()} {f.Commerce.ProductMaterial()}")
                .RuleFor(x => x.Facet, f => f.Random.Bool())
                .RuleFor(x => x.RenderInEditor, f => f.Random.Bool(0.85f))
                .RuleFor(x => x.DisplayOnSite, f => f.Random.Bool(0.85f))
                .RuleFor(x => x.Searchable, f => f.Random.Bool());

            _definitionFieldDescriptionFaker = new Faker<UCommerceProductDefinitionFieldDescription>()
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.DisplayName, f => f.Lorem.Word());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var fields = await GenerateDefinitionFields(context);
            await GenerateFieldDescriptions(context, fields);
        }


        private async Task<UCommerceProductDefinitionField[]> GenerateDefinitionFields(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count:N0} product definition fields. ");
            using (var p = new ProgressBar())
            {
                var dataTypeIds = context.UCommerceDataType.Select(x => x.DataTypeId).ToArray();

                var allProductDefinitionIds =
                    context.UCommerceProductDefinition.Select(x => x.ProductDefinitionId).ToList();
                var oneHalfProductDefinitionIds =
                    allProductDefinitionIds.Take(allProductDefinitionIds.Count / 2).ToList();
                var oneHalfProductFamiliyDefinitionIds =
                    allProductDefinitionIds.Skip(allProductDefinitionIds.Count / 2).ToList();

                UCommerceProductDefinitionField[] familyDefinitionFields = GeneratorHelper.Generate(
                    () => GenerateDefinitionFieldForFamily(oneHalfProductFamiliyDefinitionIds, dataTypeIds), Count / 2);
                
                UCommerceProductDefinitionField[] definitionFields = GeneratorHelper.Generate(
                    () => GenerateDefinitionFieldForNonFamily(oneHalfProductDefinitionIds, dataTypeIds), Count / 2);

                var allFields = familyDefinitionFields.Concat(definitionFields).ToArray();
                p.Report(0.25);

                allFields.ConsecutiveSortOrder((f, v) => { f.SortOrder = (int) v; });
                p.Report(0.50);

                allFields = allFields
                    .Where(f => f.Name != "name")
                    .DistinctBy(f => new CompositeKey {Key1 = f.Name.GetHashCode(), Key2 = f.ProductDefinitionId})
                    .ToArray();
                p.Report(0.75);
                await context.BulkInsertAsync(allFields);
                return allFields;
            }
        }

        private async Task GenerateFieldDescriptions(UmbracoDbContext context, UCommerceProductDefinitionField[] fields)
        {
            Console.Write($"Generating descriptions for {fields.Length:N0} product definition fields. ");
            using (var p = new ProgressBar())
            {
                var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
                var descriptions = fields.SelectMany(field =>
                    languageCodes.Select(language =>
                        _definitionFieldDescriptionFaker
                            .RuleFor(x => x.ProductDefinitionFieldId, f => field.ProductDefinitionFieldId)
                            .RuleFor(x => x.CultureCode, f => language)
                            .Generate()
                    )
                );
                p.Report(0.5);
                await context.BulkInsertAsync(descriptions, options => options.AutoMapOutputDirection = false);
            }
        }

        private UCommerceProductDefinitionField GenerateDefinitionFieldForFamily(List<int> productDefinitionIds,
            int[] dataTypeIds)
        {
            return _productDefinitionFieldFaker
                .RuleFor(x => x.ProductDefinitionId, f => f.PickRandom(productDefinitionIds))
                .RuleFor(x => x.DataTypeId, f => f.PickRandom(dataTypeIds))
                .RuleFor(x => x.IsVariantProperty, f => f.Random.Bool(0.75f))
                .Generate();
        }

        private UCommerceProductDefinitionField GenerateDefinitionFieldForNonFamily(List<int> productDefinitionIds,
            int[] dataTypeIds)
        {
            return _productDefinitionFieldFaker
                .RuleFor(x => x.ProductDefinitionId, f => f.PickRandom(productDefinitionIds))
                .RuleFor(x => x.DataTypeId, f => f.PickRandom(dataTypeIds))
                .RuleFor(x => x.IsVariantProperty, f => false)
                .Generate();
        }
    }
}