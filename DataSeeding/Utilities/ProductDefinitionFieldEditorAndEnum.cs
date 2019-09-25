using System;
using System.Collections.Generic;
using Ucommerce.Seeder.Models;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    public class ProductDefinitionFieldEditorAndEnum
    {
        public UCommerceProductDefinitionField Field { get; }
        public string Editor { get; }
        public IEnumerable<Guid> Enums { get; }

        public ProductDefinitionFieldEditorAndEnum(UCommerceProductDefinitionField field, string editor,
            IEnumerable<Guid> enums)
        {
            this.Field = field;
            Editor = editor;
            Enums = enums;
        }
    }
}