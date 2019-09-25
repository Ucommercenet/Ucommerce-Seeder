using Ucommerce.Seeder.DataSeeding.Tasks;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategory
    {
        public CompositeKey UniqueIndex()
        {
            return new CompositeKey {Key1 = Name.GetHashCode(), Key2 = ParentCategoryId ?? 0, Key3 = ProductCatalogId};
        }
    }
}