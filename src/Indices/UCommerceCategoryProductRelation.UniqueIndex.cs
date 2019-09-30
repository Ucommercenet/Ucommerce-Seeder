namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategoryProductRelation
    {
        public CompositeKey UniqueIndex()
        {
            return new CompositeKey {Key1 = CategoryId, Key2 = ProductId, Key3 = 0};
        }
    }
}