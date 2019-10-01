using System;
using System.Collections.Generic;
using System.Linq;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    public class DefinitionFieldEditorAndEnum
    {
        public UCommerceDefinitionField Field { get; }
        public string Editor { get; }
        public Guid[] Enums { get; }

        public DefinitionFieldEditorAndEnum(UCommerceDefinitionField field, string editor,
            IEnumerable<Guid> enums)
        {
            this.Field = field;
            Editor = editor;
            Enums = enums.ToArray();
        }
    }
}