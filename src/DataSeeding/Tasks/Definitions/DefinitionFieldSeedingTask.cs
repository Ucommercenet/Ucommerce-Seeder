using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.DataSeeding.Tasks.Cms;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class DefinitionFieldSeedingTask : DataSeedingTaskBase
    {
        private readonly ICmsContent _cmsContent;
        private readonly Faker<UCommerceDefinitionField> _definitionFieldFaker;
        private readonly Faker<UCommerceDefinitionFieldDescription> _definitionFieldDescriptionFaker;

        public DefinitionFieldSeedingTask(uint count, ICmsContent cmsContent) : base(count)
        {
            _cmsContent = cmsContent;
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

        public override void Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition.Select(x => x.DefinitionId).ToArray();
            var dataTypeIds = context.UCommerceDataType.Select(x => x.DataTypeId).ToArray();

            var fields = GenerateFields(context, definitionIds, dataTypeIds);

            GenerateDescriptions(context, fields);
        }

        private void GenerateDescriptions(UmbracoDbContext context, IEnumerable<UCommerceDefinitionField> fields)
        {
            Console.Write($"Generating descriptions for {Count:N0} definition fields. ");
            using (var p = new ProgressBar())
            {
                var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
                var descriptions = fields.SelectMany(field =>
                    languageCodes.Select(language =>
                        _definitionFieldDescriptionFaker
                            .RuleFor(x => x.DefinitionFieldId, f => field.DefinitionFieldId)
                            .RuleFor(x => x.CultureCode, f => language)
                            .Generate()
                    )
                );
                p.Report(0.5);
                context.BulkInsert(descriptions.ToList(), options => options.SetOutputIdentity = false);
            }
        }

        private List<UCommerceDefinitionField> GenerateFields(UmbracoDbContext context, int[] definitionIds,
            int[] dataTypeIds)
        {
            Console.Write($"Generating {Count:N0} definition fields. ");
            using (var p = new ProgressBar())
            {
                var fields = GeneratorHelper.Generate(() => GenerateField(definitionIds, dataTypeIds), Count).ToList();
                fields.ConsecutiveSortOrder((f, v) => { f.SortOrder = (int) v; });
                p.Report(0.5);
                context.BulkInsert(fields);
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