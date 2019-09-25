﻿using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoDocumentCultureVariation
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public int LanguageId { get; set; }
        public bool Edited { get; set; }
        public bool Available { get; set; }
        public bool Published { get; set; }
        public string Name { get; set; }

        public virtual UmbracoLanguage Language { get; set; }
        public virtual UmbracoNode Node { get; set; }
    }
}
