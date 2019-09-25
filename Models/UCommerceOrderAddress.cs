using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderAddress
    {
        public UCommerceOrderAddress()
        {
            UCommercePurchaseOrder = new HashSet<UCommercePurchaseOrder>();
            UCommerceShipment = new HashSet<UCommerceShipment>();
        }

        public int OrderAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        public string Attention { get; set; }
        public string CompanyName { get; set; }
        public string AddressName { get; set; }
        public int? OrderId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCountry Country { get; set; }
        public virtual UCommercePurchaseOrder Order { get; set; }
        public virtual ICollection<UCommercePurchaseOrder> UCommercePurchaseOrder { get; set; }
        public virtual ICollection<UCommerceShipment> UCommerceShipment { get; set; }
    }
}
