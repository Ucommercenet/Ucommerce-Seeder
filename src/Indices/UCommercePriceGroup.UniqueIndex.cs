namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePriceGroup
    {
        public CompositeKey UniqueIndex()
        {
            return new CompositeKey {Key1 = Name.GetHashCode(), Key2 = 0, Key3 = 0};
        }
    }
}