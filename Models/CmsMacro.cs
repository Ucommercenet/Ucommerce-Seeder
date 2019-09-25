using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsMacro
    {
        public CmsMacro()
        {
            CmsMacroProperty = new HashSet<CmsMacroProperty>();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public bool? MacroUseInEditor { get; set; }
        public int MacroRefreshRate { get; set; }
        public string MacroAlias { get; set; }
        public string MacroName { get; set; }
        public bool? MacroCacheByPage { get; set; }
        public bool? MacroCachePersonalized { get; set; }
        public bool? MacroDontRender { get; set; }
        public string MacroSource { get; set; }
        public int MacroType { get; set; }

        public virtual ICollection<CmsMacroProperty> CmsMacroProperty { get; set; }
    }
}
