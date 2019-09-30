using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class DefinitionFieldSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceDefinitionField> _definitionFieldFaker;
        private readonly Faker<UCommerceDefinitionFieldDescription> _definitionFieldDescriptionFaker;

        public DefinitionFieldSeedingTask(uint count) : base(count)
        {
            _definitionFieldFaker = new Faker<UCommerceDefinitionField>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Multilingual, f => f.Random.Bool())
                .RuleFor(x => x.Name, f => $"{f.Commerce.Color()} {f.Commerce.Product()}")
                .RuleFor(x => x.Searchable, f => f.Random.Bool())
                .RuleFor(x => x.BuiltIn, f => false)
                .RuleFor(x => x.DefaultValue, f => null)
                .RuleFor(x => x.DisplayOnSite, f => f.Random.Bool())
                .RuleFor(x => x.RenderInEditor, f => f.Random.Bool());

            _definitionFieldDescriptionFaker = new Faker<UCommerceDefinitionFieldDescription>()
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.DisplayName, f => f.Lorem.Word());
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition.Select(x => x.DefinitionId).ToArray();
            var dataTypeIds = context.UCommerceDataType.Select(x => x.DataTypeId).ToArray();

            var fields = await GenerateFields(context, definitionIds, dataTypeIds);

            await GenerateDescriptions(context, fields);
        }

        private async Task GenerateDescriptions(UmbracoDbContext context, UCommerceDefinitionField[] fields)
        {
            Console.Write($"Generating descriptions for {Count:N0} definition fields. ");
            using (var p = new ProgressBar())
            {
                var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
                var descriptions = fields.SelectMany(field =>
                    languageCodes.Select(language =>
                        _definitionFieldDescriptionFaker
                            .RuleFor(x => x.DefinitionFieldId, f => field.DefinitionFieldId)
                            .RuleFor(x => x.CultureCode, f => language)
                            .Generate()
                    )
                );
                p.Report(0.5);
                await context.BulkInsertAsync(descriptions, options => options.AutoMapOutputDirection = false);
            }
        }

        private async Task<UCommerceDefinitionField[]> GenerateFields(UmbracoDbContext context, int[] definitionIds,
            int[] dataTypeIds)
        {
            Console.Write($"Generating {Count:N0} definition fields. ");
            using (var p = new ProgressBar())
            {
                var fields = GeneratorHelper.Generate(() => GenerateField(definitionIds, dataTypeIds), Count);
                fields.ConsecutiveSortOrder((f, v) => { f.SortOrder = (int) v; });
                p.Report(0.5);
                await context.BulkInsertAsync(fields);
                return fields;
            }
        }

        private UCommerceDefinitionField GenerateField(int[] definitionIds, int[] dataTypeIds)
        {
            return _definitionFieldFaker
                .RuleFor(x => x.DataTypeId, f => f.PickRandom(dataTypeIds))
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .Generate();
        }

    }
}