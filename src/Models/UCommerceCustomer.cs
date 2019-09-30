using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCustomer
    {
        public UCommerceCustomer()
        {
            UCommerceAddress = new HashSet<UCommerceAddress>();
            UCommerceProductReview = new HashSet<UCommerceProductReview>();
            UCommerceProductReviewComment = new HashSet<UCommerceProductReviewComment>();
            UCommercePurchaseOrder = new HashSet<UCommercePurchaseOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string MemberId { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceAddress> UCommerceAddress { get; set; }
        public virtual ICollection<UCommerceProductReview> UCommerceProductReview { get; set; }
        public virtual ICollection<UCommerceProductReviewComment> UCommerceProductReviewComment { get; set; }
        public virtual ICollection<UCommercePurchaseOrder> UCommercePurchaseOrder { get; set; }
    }
}
