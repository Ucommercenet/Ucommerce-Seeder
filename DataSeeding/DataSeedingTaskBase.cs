using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Ucommerce.Seeder.DataSeeding.Tasks.Definitions;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;
// ReSharper disable ReplaceWithSingleCallToAny
// ReSharper disable ReplaceWithSingleCallToFirst

namespace Ucommerce.Seeder.DataSeeding
{
    public abstract class DataSeedingTaskBase : IDataSeedingTask
    {

        private readonly uint _count;
        protected readonly Faker<UCommerceEntityProperty> EntityPropertyFaker;
        protected readonly Faker<UCommerceEntityProperty> EntityFieldDescriptionFaker;

        public DataSeedingTaskBase(uint count)
        {
            _count = count;
            EntityPropertyFaker = new Faker<UCommerceEntityProperty>()
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Version, f => 1);
        }

        public virtual uint Count
        {
            get => _count;
        }

        public abstract Task Seed(UmbracoDbContext context);


        protected IEnumerable<UCommerceEntityProperty> AddEntityProperty(Guid entityGuid,
            UCommerceDefinitionField field, string[] languageCodes, Guid[] mediaIds, Guid[] contentIds, string editor,
            Guid[] enumGuids)
        {
            if (field.Multilingual)
            {
                return languageCodes.Select(languageCode =>
                {
                    return EntityPropertyFaker
                        .RuleFor(x => x.DefinitionFieldId, f => field.DefinitionFieldId)
                        .RuleFor(x => x.EntityId, f => entityGuid)
                        .RuleFor(x => x.CultureCode, f => languageCode)
                        .RuleFor(x => x.Value, f => BogusProperty.BogusValue(mediaIds, contentIds, editor, enumGuids))
                        .Generate();
                });
            }
            else
            {
                return new[]
                {
                    EntityPropertyFaker
                        .RuleFor(x => x.DefinitionFieldId, f => field.DefinitionFieldId)
                        .RuleFor(x => x.EntityId, f => entityGuid)
                        .RuleFor(x => x.CultureCode, f => null)
                        .RuleFor(x => x.Value, f => BogusProperty.BogusValue(mediaIds, contentIds, editor, enumGuids))
                        .Generate()
                };
            }
        }
        
        protected ILookup<int, DefinitionFieldEditorAndEnum> LookupDefinitionFields(UmbracoDbContext context, int[] definitionIds)
        {
            return context.UCommerceDefinitionField
                .Where(field => definitionIds.Contains(field.DefinitionId))
                .Select(field => new DefinitionFieldEditorAndEnum(field,
                    field.DataType.Definition.UCommerceDefinitionField.Where(x => x.Name == "Editor").Any() ? field.DataType.Definition.UCommerceDefinitionField.Where(x => x.Name == "Editor").First()
                        .UCommerceEntityProperty.Where(x => x.EntityId == field.DataType.Guid).Select(x => x.Value).FirstOrDefault() : "",
                    field.DataType.UCommerceDataTypeEnum.Select(x => x.Guid)))
                .ToLookup(field => field.Field.DefinitionId);
        }
    }
}