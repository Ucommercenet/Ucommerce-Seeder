using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DataTypeSeedingTask : DataSeedingTaskBase
    {
        private readonly ICmsContent _cmsContent;
        private readonly Faker<UCommerceDataType> _datatypeFaker;
        private readonly Faker _faker = new Faker();

        public DataTypeSeedingTask(uint count, ICmsContent cmsContent) : base(count)
        {
            _cmsContent = cmsContent;
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

        public override void Seed(UmbracoDbContext context)
        {
            var definitionIds = context.UCommerceDefinition
                .Where(d => d.DefinitionTypeId == (int) DefinitionType.DataType).Select(c => c.DefinitionId)
                .ToArray();
            var definitionFields = LookupDefinitionFields(context, definitionIds);

            var dataTypes = GenerateDataTypes(context, definitionIds);
            GenerateProperties(context, dataTypes, definitionFields);
        }

        private void GenerateProperties(UmbracoDbContext context, IEnumerable<UCommerceDataType> dataTypes,
            ILookup<int, DefinitionFieldEditorAndEnum> definitionFields)
        {
            Console.Write($"Generating properties for {Count:N0} data types.");
            using (var p = new ProgressBar())
            {
                var languageCodes = _cmsContent.GetLanguageIsoCodes(context);
                var mediaIds = _cmsContent.GetAllMediaIds(context);
                var contentIds = _cmsContent.GetAllContentIds(context);

                UCommerceEntityProperty[] properties = dataTypes
                    .Where(dataType => dataType.DefinitionId.HasValue)
                    .SelectMany(dataType => definitionFields[dataType.DefinitionId.Value].SelectMany(field =>
                        AddEntityProperty(dataType.Guid, field.Field, languageCodes, mediaIds,
                            contentIds, field.Editor, field.Enums)))
                    .ToArray();

                p.Report(0.5);
                context.BulkInsert(properties, options => options.SetOutputIdentity = false);
            }
        }

        private List<UCommerceDataType> GenerateDataTypes(UmbracoDbContext context, int[] definitionIds)
        {
            Console.Write($"Generating {Count:N0} data types.");
            using (var p = new ProgressBar())
            {
                var dataTypes = GeneratorHelper.Generate(() => Generate(definitionIds), Count).ToList();
                p.Report(0.5);
                context.BulkInsert(dataTypes);
                return dataTypes;
            }
        }

        private UCommerceDataType Generate(int[] definitionIds)
        {
            return _datatypeFaker
                .RuleFor(x => x.DefinitionId, f => f.PickRandom(definitionIds))
                .RuleFor(x => x.DefinitionName, f => f.PickRandom<BuiltInEditors>().ToString())
                .Generate();
        }
    }
}