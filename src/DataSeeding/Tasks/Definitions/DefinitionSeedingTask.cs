using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataAccess;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks.Definitions
{
    public class DefinitionSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker<UCommerceDefinition> _definitionFaker;

        public DefinitionSeedingTask(uint count) : base(count)
        {
            _definitionFaker = new Faker<UCommerceDefinition>()
                .RuleFor(x => x.Deleted, f => f.Random.Bool(0.001f))
                .RuleFor(x => x.Description, f => f.Lorem.Sentence())
                .RuleFor(x => x.Guid, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .RuleFor(x => x.BuiltIn, f => false)
                .RuleFor(x => x.CreatedBy, f => f.Name.FullName())
                .RuleFor(x => x.CreatedOn, f => f.Date.Past())
                .RuleFor(x => x.ModifiedBy, f => f.Name.FullName())
                .RuleFor(x => x.ModifiedOn, f => f.Date.Recent());
        }

        public override void Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count:N0} definitions. ");
            using (var p = new ProgressBar())
            {
                var catalogDefinitions = Enum.GetValues(typeof(DefinitionType))
                    .Cast<DefinitionType>()
                    .SelectMany(definitionType => GeneratorHelper.Generate(() => Generate(definitionType), Count));
                p.Report(0.33);
                catalogDefinitions.ConsecutiveSortOrder((f, v) => { f.SortOrder = (int) v; });
                p.Report(0.66);
                context.BulkInsert(catalogDefinitions.ToList(), options => options.SetOutputIdentity = false);
            }
        }

        private UCommerceDefinition Generate(DefinitionType definitionType)
        {
            return _definitionFaker
                .RuleFor(x => x.DefinitionTypeId, f => (int) definitionType)
                .Generate();
        }
    }
}