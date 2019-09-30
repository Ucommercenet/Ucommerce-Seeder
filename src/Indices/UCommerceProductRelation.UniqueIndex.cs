namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductRelation
    {
        public CompositeKey UniqueIndex()
        {
            return new CompositeKey {Key1 = ProductId, Key2 = RelatedProductId, Key3 = ProductRelationTypeId};
        }
    }
}