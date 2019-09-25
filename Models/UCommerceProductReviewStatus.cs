using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductReviewStatus
    {
        public UCommerceProductReviewStatus()
        {
            UCommerceProductReview = new HashSet<UCommerceProductReview>();
            UCommerceProductReviewComment = new HashSet<UCommerceProductReviewComment>();
        }

        public int ProductReviewStatusId { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceProductReview> UCommerceProductReview { get; set; }
        public virtual ICollection<UCommerceProductReviewComment> UCommerceProductReviewComment { get; set; }
    }
}
