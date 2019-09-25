using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class DataTypeSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceDataType> _datatypeFaker;
        private readonly Faker _faker = new Faker();

        public DataTypeSeedingTask(uint count) : base(count)
        {
            _datatypeFaker = new Faker<UCommerceDataType>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Nullable, f => f.Random.Bool())
                .RuleFor(x => x.BuiltIn, f => false)
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent())
                .RuleFor(x => x.TypeName, f => f.Database.Type())
                .RuleFor(x => x.ValidationExpression, f => "");
        }

        public override async Task Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.DataType).Select(c => c.DefinitionId)
                .ToArray();
            var definitionFields = LookupDefinitionFields(context, definitionIds);

            var dataTypes = await GenerateDataTypes(context, definitionIds);
            await GenerateProperties(context, dataTypes, definitionFields);
        }

        private async Task GenerateProperties(UmbracoDbContext context, UCommerceDataType[] dataTypes,
            ILookup<int, DefinitionFieldEditorAndEnum> definitionFields)
        {
            Console.Write($"Generating properties for {Count:N0} data types.");
            using (var p = new ProgressBar())
            {
                var languageCodes = context.UmbracoLanguage.Select(x => x.LanguageIsocode).ToArray();
                var mediaIds = GetAllMediaIds(context);
                var contentIds = GetAllContentIds(context);

                UCommerceEntityProperty[] properties = dataTypes
                    .Where(dataType => dataType.DefinitionId.HasValue)
                    .SelectMany(dataType => definitionFields[dataType.DefinitionId.Value].SelectMany(field =>
                        AddEntityProperty(dataType.Guid, field.Field, languageCodes, mediaIds,
                            contentIds, field.Editor, field.Enums)))
                    .ToArray();

                p.Report(0.5);
                await context.BulkInsertAsync(properties, options => options.AutoMapOutputDirection = false);
            }
        }

        private async Task<UCommerceDataType[]> GenerateDataTypes(UmbracoDbContext context, int[] definitionIds)
        {
            Console.Write($"Generating {Count:N0} data types.");
            using (var p = new ProgressBar())
            {
                var dataTypes = GeneratorHelper.Generate(() => Generate(definitionIds), Count);
                p.Report(0.5);
                await context.BulkInsertAsync(dataTypes);
                return dataTypes;
            }
        }

        private UCommerceDataType Generate(int[] definitionIds)
        {
            return _datatypeFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.DefinitionName, "?")
                .Generate();
        }

        public override async Task Truncate(UmbracoDbContext context)
        {
            await context.Database.ExecuteSqlCommandAsync(new RawSqlString($"TRUNCATE TABLE [Ucommerce_DataType]"));
        }
    }
}