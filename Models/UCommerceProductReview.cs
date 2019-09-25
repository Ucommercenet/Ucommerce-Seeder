using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductReview
    {
        public UCommerceProductReview()
        {
            UCommerceProductReviewComment = new HashSet<UCommerceProductReviewComment>();
        }

        public int ProductReviewId { get; set; }
        public int? Rating { get; set; }
        public int? CustomerId { get; set; }
        public int ProductCatalogGroupId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string CultureCode { get; set; }
        public string ReviewHeadline { get; set; }
        public string ReviewText { get; set; }
        public int ProductId { get; set; }
        public string Ip { get; set; }
        public int ProductReviewStatusId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCustomer Customer { get; set; }
        public virtual UCommerceProduct Product { get; set; }
        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
        public virtual UCommerceProductReviewStatus ProductReviewStatus { get; set; }
        public virtual ICollection<UCommerceProductReviewComment> UCommerceProductReviewComment { get; set; }
    }
}
