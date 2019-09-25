
namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalog
    {
        public CompositeKey UniqueIndex()
        {
            return new CompositeKey {Key1 = Name.GetHashCode(), Key2 = ProductCatalogGroupId, Key3 = 0};
        }
    }
}

