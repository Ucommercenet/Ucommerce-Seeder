using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductReviewComment
    {
        public int ProductReviewCommentId { get; set; }
        public int ProductReviewId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string CultureCode { get; set; }
        public string Comment { get; set; }
        public bool Helpful { get; set; }
        public bool Unhelpful { get; set; }
        public string Ip { get; set; }
        public int ProductReviewStatusId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCustomer Customer { get; set; }
        public virtual UCommerceProductReview ProductReview { get; set; }
        public virtual UCommerceProductReviewStatus ProductReviewStatus { get; set; }
    }
}
