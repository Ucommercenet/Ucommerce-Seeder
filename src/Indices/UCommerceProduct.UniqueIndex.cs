namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProduct
    {
        public CompositeKey UniqueIndex()
        {
            return new CompositeKey {Key1 = Sku?.GetHashCode() ?? 0, Key2 = VariantSku?.GetHashCode() ?? 0, Key3 = 0};
        }

    }
}