using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePayment
    {
        public UCommercePayment()
        {
            UCommercePaymentProperty = new HashSet<UCommercePaymentProperty>();
        }

        public int PaymentId { get; set; }
        public string TransactionId { get; set; }
        public string PaymentMethodName { get; set; }
        public DateTime Created { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Fee { get; set; }
        public decimal FeePercentage { get; set; }
        public int PaymentStatusId { get; set; }
        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public decimal? FeeTotal { get; set; }
        public string ReferenceId { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? GrossAmount { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePurchaseOrder Order { get; set; }
        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
        public virtual UCommercePaymentStatus PaymentStatus { get; set; }
        public virtual ICollection<UCommercePaymentProperty> UCommercePaymentProperty { get; set; }
    }
}
