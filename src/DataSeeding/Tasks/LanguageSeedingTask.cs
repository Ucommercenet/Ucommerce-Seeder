using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Ucommerce.Seeder.DataSeeding.Utilities;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Tasks
{
    public class LanguageSeedingTask : DataSeedingTaskBase
    {
        private readonly Faker _faker;
        private CultureInfo[] _pickedCultures;
        private readonly Faker<UmbracoLanguage> _languageFaker;

        public LanguageSeedingTask(uint count) : base(count)
        {
            _faker = new Faker();

            _languageFaker = new Faker<UmbracoLanguage>()
                .RuleFor(x => x.IsDefaultVariantLang, f => false)
                .RuleFor(x => x.Mandatory, f => f.Random.Bool(0.1f));
        }

        public override void Seed(UmbracoDbContext context)
        {
            Console.Write($"Generating {Count} languages. ");
            using (var p = new ProgressBar())
            {
                var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                    .Where(cultureInfo => !context.UmbracoLanguage
                        .Any(language => language.LanguageIsocode == cultureInfo.Name))
                    .ToArray();

                _pickedCultures = _faker.PickRandom(availableCultures, (int) Count).ToArray();

                var umbracoLanguages = GeneratorHelper.Generate(Generate, Count).Where(x => x != null).ToList();
                p.Report(0.5);
                context.BulkInsert(umbracoLanguages, options => options.SetOutputIdentity = false);
            }
        }

        private UmbracoLanguage Generate()
        {
            // if there's no more languages left, then just skip
            if (_pickedCultures.Length == 0)
                return null;

            // pick a random culture
            var culture = _faker.PickRandom(_pickedCultures);
            // don't pick the same twice
            _pickedCultures = _pickedCultures.Except(new[] {culture}).ToArray();

            return _languageFaker
                .RuleFor(x => x.LanguageIsocode, f => culture.Name)
                .RuleFor(x => x.LanguageCultureName, f => culture.DisplayName)
                .Generate();
        }
    }
}