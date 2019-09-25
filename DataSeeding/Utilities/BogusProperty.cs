using System;
using System.Collections.Generic;
using Bogus;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    public static class BogusProperty
    {
        private static readonly Dictionary<BuiltInEditors,
            Func<IEnumerable<Guid>, IEnumerable<Guid>, IEnumerable<Guid>, string>> _values =
            new Dictionary<BuiltInEditors, Func<IEnumerable<Guid>, IEnumerable<Guid>, IEnumerable<Guid>, string>>
            {
                {BuiltInEditors.RichText, (mediaGuids, contentGuids, enumGuids) => _faker.Lorem.Paragraphs(3)},
                {
                    BuiltInEditors.Media,
                    (mediaGuids, contentGuids, enumGuids) => _faker.PickRandom(mediaGuids).ToString()
                },
                {
                    BuiltInEditors.Content,
                    (mediaGuids, contentGuids, enumGuids) => _faker.PickRandom(contentGuids).ToString()
                },
                {
                    BuiltInEditors.EmailContent,
                    (mediaGuids, contentGuids, enumGuids) => _faker.PickRandom(contentGuids).ToString()
                },
                {BuiltInEditors.DateTime, (mediaGuids, contentGuids, enumGuids) => _faker.Date.Recent().ToString()},
                {BuiltInEditors.Boolean, (mediaGuids, contentGuids, enumGuids) => _faker.Random.Bool().ToString()},
                {
                    BuiltInEditors.ImagePickerMultiSelect,
                    (mediaGuids, contentGuids, enumGuids) =>
                        String.Join("|", _faker.PickRandom(mediaGuids, _faker.Random.UShort(0, 5)))
                },
                {BuiltInEditors.ShortText, (mediaGuids, contentGuids, enumGuids) => _faker.Lorem.Sentence()},
                {BuiltInEditors.LongText, (mediaGuids, contentGuids, enumGuids) => _faker.Lorem.Sentences(3)},
                {
                    BuiltInEditors.Number,
                    (mediaGuids, contentGuids, enumGuids) => _faker.Random.Int(0, 1_000_000).ToString()
                },
                {BuiltInEditors.DatePicker, (mediaGuids, contentGuids, enumGuids) => _faker.Date.Soon().ToString()},
                {BuiltInEditors.DateTimePicker, (mediaGuids, contentGuids, enumGuids) => _faker.Date.Soon().ToString()},
                {
                    BuiltInEditors.Enum,
                    (mediaGuids, contentGuids, enumGuids) => _faker
                        .PickRandom(enumGuids).ToString()
                },
                {
                    BuiltInEditors.EnumMultiSelect,
                    (mediaGuids, contentGuids, enumGuids) => String.Join("|", _faker
                        .PickRandom(enumGuids, _faker.Random.Int(0, 5)))
                },
            };

        // ReSharper disable once InconsistentNaming
        private static readonly Faker _faker = new Faker();

        public static string BogusValue(IEnumerable<Guid> mediaGuids, IEnumerable<Guid> contentGuids, string editor,
            IEnumerable<Guid> enums)
        {
            if (Enum.TryParse(editor, out BuiltInEditors editorEnum))
            {
                return _values[editorEnum](mediaGuids, contentGuids, enums);
            }

            return "";
        }
    }
}